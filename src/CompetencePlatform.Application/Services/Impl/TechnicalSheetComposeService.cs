using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.DataAccess.Repositories.Impl;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Utils;
using CompetencePlatform.Shared.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services.Impl
{
    public class TechnicalSheetComposeService : ITechnicalSheetComposeService
    {
        private readonly ITechnicalSheetComposeRepository _technicalSheetComposeRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public TechnicalSheetComposeService(ITechnicalSheetComposeRepository technicalSheetComposeRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _technicalSheetComposeRepository = technicalSheetComposeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<TechnicalSheetComposeModel> Create(TechnicalSheetComposeModel entity)
        {
            try
            {
                var result = await _technicalSheetComposeRepository.AddAsync(_mapper.Map<TechnicalSheetCompose>(entity));
                return _mapper.Map<TechnicalSheetComposeModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TechnicalSheetComposeModel> Delete(int id)
        {
            try
            {
                var result = await _technicalSheetComposeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _technicalSheetComposeRepository.DeleteAsync(result);
                    return _mapper.Map<TechnicalSheetComposeModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Technical Sheet Compose");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TechnicalSheetComposeModel>> Get()
        {
            try
            {
                var result = await _technicalSheetComposeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<TechnicalSheetComposeModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TechnicalSheetComposeModel> Get(int id)
        {
            try
            {
                var result = await _technicalSheetComposeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Team");
                return _mapper.Map<TechnicalSheetComposeModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<TechnicalSheetComposeModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<TechnicalSheetCompose, bool>> where = priority == true ?
                 where = k => (k.EmployeeProfile.Name.Contains(options.Search.Value) || k.Quantity.ToString().Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.EmployeeProfile.Name.Contains(options.Search.Value) || k.Quantity.ToString().Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<TechnicalSheetCompose, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "employeeProfileName":
                        order = col => col.EmployeeProfile.Name;
                        break;
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;

                   
                }

                var obj = await _technicalSheetComposeRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<TechnicalSheetComposeModel>>(obj);
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

        public async Task<TechnicalSheetComposeModel> Update(TechnicalSheetComposeModel entity)
        {
            try
            {
                var employee = await _technicalSheetComposeRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Technical Sheet");

                var result = await _technicalSheetComposeRepository.UpdateAsync(_mapper.Map<TechnicalSheetCompose>(entity));
                return _mapper.Map<TechnicalSheetComposeModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
