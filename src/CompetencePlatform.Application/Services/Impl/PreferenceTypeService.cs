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
    public class PreferenceTypeService : IPreferenceTypeService
    {
        private readonly IPreferenceTypeRepository _preferenceTypeRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public PreferenceTypeService(IPreferenceTypeRepository preferenceTypeRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _preferenceTypeRepository = preferenceTypeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<PreferenceTypeModel> Create(PreferenceTypeModel entity)
        {
            try
            {
                var result = await _preferenceTypeRepository.AddAsync(_mapper.Map<PreferenceType>(entity));
                return _mapper.Map<PreferenceTypeModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PreferenceTypeModel> Delete(int id)
        {
            try
            {
                var result = await _preferenceTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _preferenceTypeRepository.DeleteAsync(result);
                    return _mapper.Map<PreferenceTypeModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra la preferencia");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PreferenceTypeModel>> Get()
        {
            try
            {
                var result = await _preferenceTypeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<PreferenceTypeModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PreferenceTypeModel> Get(int id)
        {
            try
            {
                var result = await  _preferenceTypeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Preferencia ");
                return _mapper.Map<PreferenceTypeModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<PreferenceTypeModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<PreferenceType, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value)  || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<PreferenceType, object>> order;

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

                var obj = await _preferenceTypeRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<PreferenceTypeModel>>(obj);
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
                var result = await _preferenceTypeRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PreferenceTypeModel> Update(PreferenceTypeModel entity)
        {
            try
            {
                var employee = await _preferenceTypeRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo de  Preference");

                var result = await _preferenceTypeRepository.UpdateAsync(_mapper.Map<PreferenceType>(entity));
                return _mapper.Map<PreferenceTypeModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
