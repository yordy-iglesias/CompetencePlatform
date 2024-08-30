using AutoMapper;
using CompetencePlatform.Application.Common.Email;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Role;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Application.Templates;
using CompetencePlatform.Core.DataAccess;
using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.DataAccess.Repositories.Impl;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities.Identity;
using CompetencePlatform.Core.Enums;
using CompetencePlatform.Core.Utils;
using CompetencePlatform.Shared.Services;
using CompetencePlatform.Shared.Services.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;


namespace CompetencePlatform.Application.Services.Impl;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IConfiguration _configuration;
    private readonly IClaimService _claimService;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;

    public RoleService(IRoleRepository roleRepository,
        IConfiguration configuration,
        IClaimService claimService,
        IUserRepository userRepository,
        IMapper mapper,
        RoleManager<Role> roleManager)
    {
        _roleRepository = roleRepository;
        _configuration = configuration;
        _claimService = claimService;
        _userRepository = userRepository;
        _mapper = mapper;
        _roleManager = roleManager;
    }

    public async Task<RoleViewModel> Update(RoleAccess model, int id)
    {
        try
        {
            var currentUserId = _claimService.GetUserId();

            if (currentUserId == null)
                throw new BadRequestException("No se encontró al usuario");

            var roleByUserId = await _userRepository.GetRolByIdUser(currentUserId);

            if (roleByUserId == null)
                throw new BadRequestException("No se encontró el Rol");

            var permission = JwtHelper.GetPermissionOfToken(roleByUserId[0].ConcurrencyStamp, Enum.GetName(typeof(ModuleEnum), 2));

            if (permission == null || !permission.Actions.Contains(Enum.GetName(typeof(PermissionEnum), 3)))
                throw new BadRequestException("No tienes permiso para realizar esta accción.");

            var role = await _roleRepository.GetFirstAsync(x => x.Id == id, asNoTracking: false);

            if (role == null) throw new BadRequestException("No se encontró el Rol");

           

            string stamp = JwtHelper.GenerateRoleToken(model, _configuration);

            if (role.Name != model.RolName)
            {
                role.Name = model.RolName;
                role.NormalizedName = model.RolName.ToUpper();
            }

            if (role.ConcurrencyStamp != stamp)
                role.ConcurrencyStamp = model.Permisions.Count != 0 ? stamp : null;

            return _mapper.Map<RoleViewModel>(await _roleRepository.UpdateAsync(role));
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<DataTablePagin<RoleViewModel>> GetPagination(DataTableServerSide options)
    {
        try
        {
            var currentUserId = _claimService.GetUserId();

            if (currentUserId == null)
                throw new BadRequestException("No se encontró al usuario");

            var roleByUserId = await _userRepository.GetRolByIdUser(currentUserId);

            if (roleByUserId == null)
                throw new BadRequestException("No se encontró el Rol");

            var permission = JwtHelper.GetPermissionOfToken(roleByUserId[0].ConcurrencyStamp, Enum.GetName(typeof(ModuleEnum), 2));

            if (permission == null || !permission.Actions.Contains(Enum.GetName(typeof(PermissionEnum), 1)))
                throw new BadRequestException("No tienes permiso para ver está sección");

            var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
            var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

            Expression<Func<Role, bool>> where = priority == true ?
                where = s => (s.Name.Contains(options.Search.Value) || s.NormalizedName.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = s => (s.Name.Contains(options.Search.Value) || s.NormalizedName.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value));

            Expression<Func<Role, object>> order = area => area.Name;

            int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
            string nameColumnOrder = options.Columns[columnsOrder].Name;
            SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

            var obj = await _roleRepository.GetPage(new PageInfo
            {
                PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                PageSize = options.Length
            }, where, order, sort);

            obj.OrderColumnName = nameColumnOrder;

            var result = _mapper.Map<DataTablePagin<RoleViewModel>>(obj);

            result.Draw = options.Draw;

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<RoleViewModel> Create(RoleAccess model)
    {
        try
        {
            var currentUserId = _claimService.GetUserId();

            if (currentUserId == null)
                throw new BadRequestException("No se encontró al usuario");

            var roleByUserId = await _userRepository.GetRolByIdUser(currentUserId);

            if (roleByUserId == null)
                throw new BadRequestException("No se encontró el Rol");

            var permission = JwtHelper.GetPermissionOfToken(roleByUserId[0].ConcurrencyStamp, Enum.GetName(typeof(ModuleEnum), 2));

            if (permission == null || !permission.Actions.Contains(Enum.GetName(typeof(PermissionEnum), 2)))
                throw new BadRequestException("No tienes permiso para realizar esta accción.");

            // model.RolId = Guid.NewGuid();

            string stamp = JwtHelper.GenerateRoleToken(model, _configuration);
            var role = new Role(model.RolName);

            role.NormalizedName = model.RolName.ToUpper();
            role.ConcurrencyStamp = model.Permisions.Count != 0 ? stamp : null;

            return _mapper.Map<RoleViewModel>(await _roleRepository.AddAsync(role));
        }
        catch
        {
            throw;
        }
    }

    public async Task<RoleViewModel> Delete(int id)
    {
        try
        {
            var currentUserId = _claimService.GetUserId();

            if (currentUserId == null) throw new BadRequestException("No se encontró al usuario");

            var roleByUserId = await _userRepository.GetRolByIdUser(currentUserId);

            if (roleByUserId == null)
                throw new BadRequestException("No se encontró el Rol");

            var permission = JwtHelper.GetPermissionOfToken(roleByUserId[0].ConcurrencyStamp, Enum.GetName(typeof(ModuleEnum), 2));

            if (permission == null || !permission.Actions.Contains(Enum.GetName(typeof(PermissionEnum), 4)))
                throw new BadRequestException("No tienes permiso para realizar esta accción.");

            var role = await _roleRepository.GetFirstAsync(x => x.Id == id, asNoTracking: false);

            if (role == null) throw new BadRequestException("No se encontró el Rol");

            if (role.Name == Enum.GetName(typeof(SystemRoleEnum), 1) || role.Name == Enum.GetName(typeof(SystemRoleEnum), 2))
                throw new BadRequestException("Los roles de  \"Admin\" y \"Developer\" no pueden ser eliminados.");

            if (role.NormalizedName == roleByUserId[0].NormalizedName)
                throw new BadRequestException("No puede eliminar su propio rol.");

            return _mapper.Map<RoleViewModel>(await _roleRepository.DeleteAsync(role));
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RoleViewModel> Get(int id)
    {
        try
        {
            var role = await _roleRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);

            if (role == null)
                throw new BadRequestException("No se encontró el rol.");

            return _mapper.Map<RoleViewModel>(role);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<RoleViewModel>> Get()
    {
        try
        {
            return _mapper.Map<IEnumerable<RoleViewModel>>(await _roleRepository.GetAllAsync());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<RoleViewModel> Create(RoleViewModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<RoleViewModel> Update(RoleViewModel entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SelectViewModel>> GetSelect()
    {
        try
        {
            var result = await _roleRepository.GetAllAsync(x => x.Name);
            return _mapper.Map<IEnumerable<SelectViewModel>>(result);
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<string>> GetScreen()
    {
        try
        {
            return Enum.GetNames(typeof(ModuleEnum));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
