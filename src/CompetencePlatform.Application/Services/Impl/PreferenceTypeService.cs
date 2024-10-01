using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
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
        private readonly IPreferenceRepository _preferenceRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        private readonly IC_S_M_K_PRepository _c_s_m_k_pRepository;
        public PreferenceTypeService(IPreferenceRepository preferenceRepository,IC_S_M_K_PRepository c_s_m_k_pRepository, IPreferenceTypeRepository preferenceTypeRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _preferenceTypeRepository = preferenceTypeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
            _c_s_m_k_pRepository = c_s_m_k_pRepository;
            _preferenceRepository = preferenceRepository;   
        }
        public async Task<PreferenceTypeViewModel> Create(CreatePreferenceTypeViewModel entity)
        {
            try
            {
                entity.IsDefault = false;
                entity.IsSelected = true;
                entity.Deleted = false;
                entity.CreatedBy = (await _userRepository.CurrentUser())?.Id;
                var result = await _preferenceTypeRepository.AddAsync(_mapper.Map<PreferenceType>(entity));
                return _mapper.Map<PreferenceTypeViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PreferenceTypeViewModel> Delete(int id)
        {
            try
            {
                var result = await _preferenceTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                result.Deleted = true;
                if (result != null)
                {
                    var resultDelete = await _preferenceTypeRepository.DeleteAsync(result);
                    return _mapper.Map<PreferenceTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra la preferencia");
            }
            catch
            {
                throw;
            }
        }
        public async Task<PreferenceTypeViewModel> DeletePrime(int id)
        {
            try
            {
                var result = await _preferenceTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    //1.Obtener preferences que se relacionan con el preference type
                    var preferences = await _preferenceRepository.GetAllAsync(x => x.PreferenceTypeId == id);
                    //2. Obtener CSMKP asociados a esos preferences
                    foreach (var p in preferences)
                    {
                        var csmkp = await _c_s_m_k_pRepository.GetAllAsync(x => x.PreferenceId == p.Id);
                        //3. Eliminar  csmkp
                        foreach (var e in csmkp)
                            await _c_s_m_k_pRepository.DeleteAsync(e);
                        //4.Eliminar competenceType 
                        await _preferenceTypeRepository.DeleteAsync(result);
                    }
                    var resultDelete = await _preferenceTypeRepository.DeleteAsync(result);
                    return _mapper.Map<PreferenceTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el preferemce type");
            }
            catch
            {
                throw;
            }
        }
        public async Task<PreferenceTypeViewModel> Restore(int id)
        {
            try
            {
                var result = await _preferenceTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
               
                if (result != null)
                {
                    result.Deleted = false;
                    var resultDelete = await _preferenceTypeRepository.UpdateAsync(result);
                    return _mapper.Map<PreferenceTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el preference type");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PreferenceTypeViewModel>> Get()
        {
            try
            {
                var result = await _preferenceTypeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<PreferenceTypeViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreatePreferenceTypeViewModel> Get(int id)
        {
            try
            {
                var result = await  _preferenceTypeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Preferencia ");
                return _mapper.Map<CreatePreferenceTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PreferenceTypeViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _preferenceTypeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<PreferenceTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<PreferenceTypeViewModel>> GetPagination(DataTableServerSide options)
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
                var result = _mapper.Map<DataTablePagin<PreferenceTypeViewModel>>(obj);
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

        public async Task<PreferenceTypeViewModel> Update(CreatePreferenceTypeViewModel entity)
        {
            try
            {
                var employee = await _preferenceTypeRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);
                entity.UpdatedBy = (await _userRepository.CurrentUser())?.Id; ;
                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo de  Preference Type");

                var result = await _preferenceTypeRepository.UpdateAsync(_mapper.Map<PreferenceType>(entity));
                return _mapper.Map<PreferenceTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> IsUnique(string name, string value)
        {
            try
            {
                Expression<Func<PreferenceType, bool>> where;
                switch (name)
                {
                    case "name":
                        where = s => s.Name == value;
                        break;
                    default:

                        return false;
                }

                var obj = await _preferenceTypeRepository.GetFirstAsync(where, false);
                return obj == null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<bool> HasChildren(int id)
        {
            var result = await _preferenceRepository.GetFirstAsync(x => x.PreferenceTypeId == id, false);
            return result != null;
        }
    }
}
