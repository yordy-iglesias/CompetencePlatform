using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.DataAccess.Repositories.Impl;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Utils;
using CompetencePlatform.Shared.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services.Impl
{
    public class BehaviorService : IBehaviorService
    {
        private readonly IBehaviorRepository _behaviorRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
       // private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
       // private readonly RoleManager<ApplicationUser> _userManager;
        public BehaviorService(UserManager<ApplicationUser> userManager,IBehaviorRepository behaviorRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _behaviorRepository = behaviorRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userManager = userManager;
            //_userRepository = userRepository;
        }
        public async Task<BehaviorViewModel> Create(CreateBehaviorViewModel entity)
        {
            try
            {
                var result = await _behaviorRepository.AddAsync(_mapper.Map<Behavior>(entity));
                return _mapper.Map<BehaviorViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BehaviorViewModel> Delete(int id)
        {
            try
            {
                var result = await _behaviorRepository.GetFirstAsync(bd => bd.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _behaviorRepository.DeleteAsync(result);
                    return _mapper.Map<BehaviorViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Behavior Dictionary");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<BehaviorViewModel>> Get()
        {
            try
            {
                var result = await _behaviorRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<BehaviorViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateBehaviorViewModel> Get(int id)
        {
            try
            {
                var result = await _behaviorRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Behavior Dictionary");
                return _mapper.Map<CreateBehaviorViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<BehaviorViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                //var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                //var user =  await _userManager.FindByIdAsync(currentUserId);
                //string username = user.UserName;
                //var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");
                var priority = true;

                Expression<Func<Behavior, bool>> where = priority == true ?
                 where = b => (b.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = b => (b.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && b.Deleted==false);

                Expression<Func<Behavior, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "name":
                        order = col => col.Name;
                        break;
                   
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                }

                var obj = await _behaviorRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<BehaviorViewModel>>(obj);
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
           throw new NotImplementedException();
        }

        public async Task<BehaviorViewModel> Update(CreateBehaviorViewModel entity)
        {
            try
            {
                var behavior = await _behaviorRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (behavior == null)
                    throw new BadRequestException("No se encuentra este tipo de Behaviour");

                var result = await _behaviorRepository.UpdateAsync(_mapper.Map<Behavior>(entity));
                return _mapper.Map<BehaviorViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<BehaviorViewModel> GetDetails(int id)
        {

            try
            {
                var result = await _behaviorRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<BehaviorViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
