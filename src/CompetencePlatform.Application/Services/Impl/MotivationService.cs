using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.Motivation;
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
    public class MotivationService : IMotivationService
    {
        private readonly IMotivationRepository _motivationRepository;
        private readonly IC_S_M_K_PRepository _c_s_m_k_pRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public MotivationService(IC_S_M_K_PRepository c_s_m_k_pRepository, IMotivationRepository motivationRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _motivationRepository = motivationRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
            _c_s_m_k_pRepository = c_s_m_k_pRepository;
        }
        public async Task<MotivationViewModel> Create(CreateMotivationViewModel entity)
        {
            try
            {
                entity.IsDefault = false;
                entity.IsSelected = false;
                entity.Deleted = false;
                entity.CreatedBy = (await _userRepository.CurrentUser())?.Id;
                var result = await _motivationRepository.AddAsync(_mapper.Map<Motivation>(entity));
                return _mapper.Map<MotivationViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MotivationViewModel> Delete(int id)
        {
            try
            {
                var result = await _motivationRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    result.Deleted = true;
                    result.UpdatedBy = (await _userRepository.CurrentUser())?.Id;
                    var resultDelete = await _motivationRepository.UpdateAsync(result);
                    return _mapper.Map<MotivationViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Motivation");
            }
            catch
            {
                throw;
            }
        }

        public async Task<MotivationViewModel> Restore(int id)
        {
            try
            {
                var result = await _motivationRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                result.Deleted = false;
                if (result != null)
                {
                    var resultDelete = await _motivationRepository.UpdateAsync(result);
                    return _mapper.Map<MotivationViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Motivation");
            }
            catch
            {
                throw;
            }
        }
        public async Task<MotivationViewModel> DeletePrime(int id)
        {
            try
            {
                try
                {
                    var result = await _motivationRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                    if (result != null)
                    {
                        //1. Obtener CSMKP asociados a ese motivation
                        var csmkp = await _c_s_m_k_pRepository.GetAllAsync(x => x.MotivationId == id);
                        //2. Eliminar  csmkp
                        foreach (var e in csmkp)
                            await _c_s_m_k_pRepository.DeleteAsync(e);
                        var resultDelete = await _motivationRepository.DeleteAsync(result);
                        return _mapper.Map<MotivationViewModel>(resultDelete);
                    }
                    throw new BadRequestException("No se encuentra el Motivation");
                }
                catch
                {
                    throw;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<MotivationViewModel>> Get()
        {
            try
            {
                var result = await _motivationRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<MotivationViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<MotivationViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _motivationRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<MotivationViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateMotivationViewModel> Get(int id)
        {
            try
            {
                var result = await _motivationRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Motivation ");
                return _mapper.Map<CreateMotivationViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<MotivationViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Motivation, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted == false);

                Expression<Func<Motivation, object>> order;

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

                var obj = await _motivationRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<MotivationViewModel>>(obj);
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
                var result = await _motivationRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<MotivationViewModel> Update(CreateMotivationViewModel entity)
        {
            try
            {
                var motivation = await _motivationRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (motivation == null)
                    throw new BadRequestException("No se encuentra este tipo de Motivation");

                var result = await _motivationRepository.UpdateAsync(_mapper.Map<Motivation>(entity));
                return _mapper.Map<MotivationViewModel>(result);
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
                Expression<Func<Motivation, bool>> where;
                switch (name)
                {
                    case "name":
                        where = s => s.Name == value;
                        break;
                    default:

                        return false;
                }

                var obj = await _motivationRepository.GetFirstAsync(where, false);
                return obj == null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<bool> HasChildren(int id)
        {
            var result = await _c_s_m_k_pRepository.GetFirstAsync(x => x.MotivationId == id, false);
            return result != null;
        }
       
    }
}
