using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.SkillType;
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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services.Impl
{
    public class CompetenceTypeService : ICompetenceTypeService
    {
        private readonly ICompetenceTypeRepository _competenceTypeRepository;
        private readonly IMapper _mapper;
        private readonly ICompetenceRepository _competenceRepository;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        private readonly IC_S_M_K_PRepository _c_s_m_k_pRepository;
        public CompetenceTypeService(IC_S_M_K_PRepository c_s_m_k_pRepository, ICompetenceRepository competenceRepository,ICompetenceTypeRepository competenceTypeRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _competenceTypeRepository = competenceTypeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
            _competenceRepository = competenceRepository;
            _c_s_m_k_pRepository = c_s_m_k_pRepository;

        }
        public async Task<CompetenceTypeViewModel> Create(CreateCompetenceTypeViewModel entity)
        {
            try
            {
                entity.IsDefault = false;
                entity.IsSelected = false;
                entity.Deleted = false;
                entity.CreatedBy = (await _userRepository.CurrentUser())?.Id;
                var result = await _competenceTypeRepository.AddAsync(_mapper.Map<CompetenceType>(entity));
                return _mapper.Map<CompetenceTypeViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompetenceTypeViewModel> Delete(int id)
        {
            try
            {
                var result = await _competenceTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
               
                if (result != null)
                {
                    result.Deleted = true;
                    result.UpdatedBy = (await _userRepository.CurrentUser())?.Id;
                    var resultDelete = await _competenceTypeRepository.UpdateAsync(result);
                    return _mapper.Map<CompetenceTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el competence type");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompetenceTypeViewModel>> Get()
        {
            try
            {
                var result = await _competenceTypeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<CompetenceTypeViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<CompetenceTypeViewModel> Restore(int id)
        {
            try
            {
                var result = await _competenceTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    result.Deleted = false;
                    var resultDelete = await _competenceTypeRepository.UpdateAsync(result);
                    return _mapper.Map<CompetenceTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el competence type");
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompetenceTypeViewModel> DeletePrime(int id)
        {
            try
            {
                var result = await _competenceTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    //1.Obtener competences que se relacionan con el competence type
                    var competences = await _competenceRepository.GetAllAsync(x => x.CompetenceTypeId == id);
                    //2. Obtener CSMKP asociados a esos skills
                    foreach (var c in competences)
                    {
                        var csmkp = await _c_s_m_k_pRepository.GetAllAsync(x => x.CompetenceId == c.Id);
                        //3. Eliminar  csmkp
                        foreach (var e in csmkp)
                            await _c_s_m_k_pRepository.DeleteAsync(e);
                        //4.Eliminar competenceType 
                        await _competenceRepository.DeleteAsync(c);
                    }
                    var resultDelete = await _competenceTypeRepository.DeleteAsync(result);
                    return _mapper.Map<CompetenceTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el competence type");
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateCompetenceTypeViewModel> Get(int id)
        {
            try
            {
                var result = await _competenceTypeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Type ");
                return _mapper.Map<CreateCompetenceTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompetenceTypeViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _competenceTypeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<CompetenceTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<CompetenceTypeViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<CompetenceType, bool>> where = priority == true ?
                 where = ctm => (ctm.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = ctm => (ctm.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value)&& ctm.Deleted==false);

                Expression<Func<CompetenceType, object>> order;

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

                var obj = await _competenceTypeRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<CompetenceTypeViewModel>>(obj);
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
                var result = await _competenceTypeRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompetenceTypeViewModel> Update(CreateCompetenceTypeViewModel entity)
        {
            try
            {
                var competence = await _competenceTypeRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);
                if (competence == null)
                    throw new BadRequestException("No se encuentra este tipo de Competence Type");
                entity.UpdatedBy = (await _userRepository.CurrentUser())?.Id; ;
                var result = await _competenceTypeRepository.UpdateAsync(_mapper.Map<CompetenceType>(entity));
                return _mapper.Map<CompetenceTypeViewModel>(result);
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
                Expression<Func<CompetenceType, bool>> where;
                switch (name)
                {
                    case "name":
                        where = s => s.Name == value;
                        break;
                    default:

                        return false;
                }

                var obj = await _competenceTypeRepository.GetFirstAsync(where, false);
                return obj == null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<bool> HasChildren(int id)
        {
            var result = await _competenceRepository.GetFirstAsync(x => x.CompetenceTypeId == id, false);
            return result != null;
        }
    }
}
