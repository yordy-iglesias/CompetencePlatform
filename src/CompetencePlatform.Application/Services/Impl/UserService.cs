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
using CompetencePlatform.Core.Utils;
using CompetencePlatform.Shared.Services;
using CompetencePlatform.Shared.Services.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;


namespace CompetencePlatform.Application.Services.Impl;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;
    private readonly SignInManager<User> _signInManager;
    private readonly ITemplateService _templateService;
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IRoleRepository _roleRepository;
    private string currentUserName;

    public UserService(IClaimService claimService,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration configuration,
        ITemplateService templateService,
        IEmailService emailService,
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher,
        IRoleRepository roleRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _claimService = claimService;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _templateService = templateService;
        _emailService = emailService;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _roleRepository = roleRepository;
    }
    public async Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel)
    {
        try
        {
            var user = _mapper.Map<User>(createUserModel);

            var result = await _userManager.CreateAsync(user, createUserModel.Password);

            if (!result.Succeeded)
                throw new BadRequestException(result.Errors.FirstOrDefault()?.Description);

            var rol = await _roleRepository.GetFirstAsync(x => x.Id == createUserModel.IdRol, asNoTracking: false);
            if (rol == null)
                throw new BadRequestException("No se encuentra este rol");

            var resultRol = await _userManager.AddToRoleAsync(user, rol.Name);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var emailTemplate = await _templateService.GetTemplateAsync(TemplateConstants.ConfirmationEmail);

            var emailBody = _templateService.ReplaceInTemplate(emailTemplate,
                new Dictionary<string, string> { { "{UserId}", user.Id.ToString() }, { "{Token}", token } });

            await _emailService.SendEmailAsync(EmailMessage.Create(user.Email, emailBody, "[SCAMM.WMS.WebBack]Confirm your email"));

            return new CreateUserResponseModel
            {
                Id = (await _userManager.FindByNameAsync(user.UserName)).Id
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<CreateUserResponseModel> UpdateAsync(CreateUserModel createUserModel)
    {
        try
        {
            var user = _mapper.Map<User>(createUserModel);
            var result = await _userRepository.GetFirstAsync(x => x.Id == user.Id, asNoTracking: true);

            if (result == null)
                throw new BadRequestException("No se encuentra este usuario");

            var resultUpdated = await _userRepository.UpdateAsync(_mapper.Map<User>(createUserModel));
            return _mapper.Map<CreateUserResponseModel>(resultUpdated);
        }
        catch
        {
            throw;
        }
    }

    //public async Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel)
    //{
    //    try
    //    {
    //        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginUserModel.Username);

    //        if (user == null)
    //            throw new NotFoundException("Username or password is incorrect");

    //        var signInResult = await _signInManager.PasswordSignInAsync(user, loginUserModel.Password, false, false);

    //        if (!signInResult.Succeeded)
    //            throw new BadRequestException("Username or password is incorrect");

    //        var token = JwtHelper.GenerateToken(user, _configuration);
    //        var rols = await _userRepository.GetRolByIdUser(user.Id);
    //        currentUserName = user.UserName;
    //        return new LoginResponseModel
    //        {
    //            Username = user.UserName,
    //            Email = user.Email,
    //            Token = token,
    //            Rol = rols,
    //        };
    //    }
    //    catch ( Exception ex )
    //    {
    //        throw ex;
    //    }
    //}
    public async Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel)
    {
        try
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginUserModel.Username);

            if (user == null)
                throw new NotFoundException("Username or password is incorrect");

            var signInResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserModel.Password);

            if (signInResult != PasswordVerificationResult.Success)
            {
                throw new BadRequestException("Username or password is incorrect");
            }

            var token = JwtHelper.GenerateToken(user, _configuration);
            var roles = await _roleRepository.GetAllAsync(x => x.UserRoles.Any(y => y.UserId == user.Id));



            return new LoginResponseModel
            {
                Username = user.UserName,
                Email = user.Email,
                Token = token,
                Role = _mapper.Map<IEnumerable<RoleViewModel>>(roles)
            };
        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred during login", ex);
        }
    }


    public async Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
    {
        var user = await _userManager.FindByIdAsync(confirmEmailModel.UserId.ToString());

        if (user == null)
            throw new UnprocessableRequestException("Your verification link is incorrect");

        var result = await _userManager.ConfirmEmailAsync(user, confirmEmailModel.Token);

        if (!result.Succeeded)
            throw new UnprocessableRequestException("Your verification link has expired");

        return new ConfirmEmailResponseModel
        {
            Confirmed = true
        };
    }

    public async Task<BaseResponseModel> ChangePasswordAsync(Guid userId, ChangePasswordModel changePasswordModel)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new NotFoundException("User does not exist anymore");

        var result =
            await _userManager.ChangePasswordAsync(user, changePasswordModel.OldPassword,
                changePasswordModel.NewPassword);

        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description);

        return new BaseResponseModel
        {
            Id = user.Id
        };
    }

    public async Task<string> GetUser(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        return user.UserName;
    }

    public async Task<IEnumerable<UserViewModel>> Get()
    {
        try
        {
            var result = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserViewModel>>(result);
        }
        catch
        {
            throw;
        }
    }

    public async Task<UserViewModel> Create(UserViewModel entity)
    {
        try
        {
  
            var result = await _userRepository.AddAsync(_mapper.Map<User>(entity));
            return _mapper.Map<UserViewModel>(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<UserViewModel> Delete(int id)
    {
        try
        {
            var result = await _userRepository.GetFirstAsync(tl => tl.Id == id, asNoTracking: false);
            if (result != null)
            {
                var resultDelete = await _userRepository.DeleteAsync(result);
                return _mapper.Map<UserViewModel>(resultDelete);
            }
            throw new BadRequestException("No se encuentra el usuario");
        }
        catch
        {
            throw;
        }
    }

    public async Task<UserViewModel> Get(int id)
    {
        try
        {
            var user = await _userRepository.GetFirstAsync(x => x.Id == id, asNoTracking: false);
            var result = _mapper.Map<UserViewModel>(user);
            if (result == null)
                throw new BadRequestException("No existe este usuario");
            var rols = await _userRepository.GetRolByIdUser(result.Id);
            result.Roles = _mapper.Map<IEnumerable<RoleViewModel>>(rols);
            return result;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<UserViewModel> Update(UserViewModel entity)
    {
        try
        {

            var result = await _userRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: false);

            if (result == null)
                throw new BadRequestException("No se encuentra este usuario");


            _mapper.Map(entity, result);


            //result.Roles = null;
            //Arreglar aqui
            var oldRoles = await _userManager.GetRolesAsync(new User() { });//await _roleRepository.GetFirstAsync(x => x.Id == result.UserRoles.FirstOrDefault().RoleId, asNoTracking: true);
            foreach (var item in oldRoles)
            {
                await _userManager.RemoveFromRoleAsync(result, item);
            }
            
            var resultUpdated = await _userRepository.UpdateAsync(result);

            var newRol = await _roleRepository.GetFirstAsync(x => x.Id == entity.IdRole, asNoTracking: true);
            await _userManager.AddToRoleAsync(resultUpdated, newRol.Name);

            return _mapper.Map<UserViewModel>(resultUpdated);
        }
        catch (Exception ex)
        {

            throw new ApplicationException("Error al actualizar el usuario", ex);
        }
    }


    public async Task<DataTablePagin<UserViewModel>> GetPagination(DataTableServerSide options)
    {
        try
        {
            var currentUserId = _claimService.GetUserId();
            if (currentUserId == null)
                throw new BadRequestException("No se encuentra un usuario valido");
            var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
            string username = user.UserName;
            var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

            Expression<Func<User, bool>> where = priority == true ?
            where = s => (s.UserName.Contains(options.Search.Value) || s.UserName.Contains(options.Search.Value) || s.FirstName.Contains(options.Search.Value) || s.LastName.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
            : where = s => (s.UserName.Contains(options.Search.Value) || s.UserName.Contains(options.Search.Value) || s.FirstName.Contains(options.Search.Value) || s.LastName.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value));

            Expression<Func<User, object>> order;

            int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
            string nameColumnOrder = options.Columns[columnsOrder].Name;
            SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

            switch (nameColumnOrder)
            {
                case "username":
                    order = col => col.UserName;
                    break;
                case "firstname":
                    order = col => col.FirstName;
                    break;
                case "lastname":
                    order = col => col.LastName;
                    break;
                default:
                    order = col => col.UserName;
                    nameColumnOrder = "username";
                    break;
            }

            var obj = await _userRepository.GetPage(new PageInfo
            {
                PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                PageSize = options.Length
            }, where, order, sort);

            obj.OrderColumnName = nameColumnOrder;
            var result = _mapper.Map<DataTablePagin<UserViewModel>>(obj);
            result.Draw = options.Draw;
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<SelectViewModel>> GetSelect()
    {
        try
        {
            var result = await _userRepository.GetAllAsync(x => x.UserName);
            return _mapper.Map<IEnumerable<SelectViewModel>>(result);
        }
        catch
        {
            throw;
        }
    }

    public async Task<string> GetCurrentUserName()
    {
        return await Task.FromResult(currentUserName);
    }
}

