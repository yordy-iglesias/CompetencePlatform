using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.DegreeCompetence;
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
    public class DegreeCompetenceService : IDegreeCompetenceService
    {
        private readonly IDegreeCompetenceRepository _degreeCompetenceRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public DegreeCompetenceService(IDegreeCompetenceRepository degreeCompetenceRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _degreeCompetenceRepository = degreeCompetenceRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<DegreeCompetenceViewModel> Create(CreateDegreeCompetenceViewModel entity)
        {
            try
            {
                entity.IsDefault = false;
                entity.IsSelected = false;
                entity.Deleted = false;
                entity.CreatedBy = (await _userRepository.CurrentUser())?.Id;
                var result = await _degreeCompetenceRepository.AddAsync(_mapper.Map<DegreeCompetence>(entity));
                return _mapper.Map<DegreeCompetenceViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DegreeCompetenceViewModel> Delete(int id)
        {
            try
            {
                var result = await _degreeCompetenceRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    result.Deleted = true;
                    result.UpdatedBy = (await _userRepository.CurrentUser())?.Id;
                    var resultDelete = await _degreeCompetenceRepository.UpdateAsync(result);
                    return _mapper.Map<DegreeCompetenceViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Degree Competence Type");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<DegreeCompetenceViewModel>> Get()
        {
            try
            {
                var result = await _degreeCompetenceRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<DegreeCompetenceViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateDegreeCompetenceViewModel> Get(int id)
        {
            try
            {
                var result = await  _degreeCompetenceRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<CreateDegreeCompetenceViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DegreeCompetenceViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _degreeCompetenceRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<DegreeCompetenceViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<DegreeCompetenceViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = true;//(await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<DegreeCompetence, bool>> where = priority == true ?
                 where = dc => (dc.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = dc => (dc.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value)&& dc.Deleted==false);

                Expression<Func<DegreeCompetence, object>> order;

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

                var obj = await _degreeCompetenceRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<DegreeCompetenceViewModel>>(obj);
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
                var result = await _degreeCompetenceRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DegreeCompetenceViewModel> Update(CreateDegreeCompetenceViewModel entity)
        {
            try
            {
                var competence = await _degreeCompetenceRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);
                if (competence == null)
                    throw new BadRequestException("No se encuentra este tipo de Competence Dictionary");
                entity.UpdatedBy = (await _userRepository.CurrentUser())?.Id;

                var result = await _degreeCompetenceRepository.UpdateAsync(_mapper.Map<DegreeCompetence>(entity));
                return _mapper.Map<DegreeCompetenceViewModel>(result);
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
                Expression<Func<DegreeCompetence, bool>> where;
                switch (name)
                {
                    case "name":
                        where = s => s.Name == value;
                        break;
                    default:

                        return false;
                }

                var obj = await _degreeCompetenceRepository.GetFirstAsync(where, false);
                return obj == null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<bool> HasChildren(int id)
        {
            //var result = await _degreeCompetenceRepository.GetFirstAsync(x => x.BehaviourDictionaries == id, false);
            return false;
        }
        public async Task<DegreeCompetenceViewModel> Restore(int id)
        {
            try
            {
                var result = await _degreeCompetenceRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    result.Deleted = false;
                    var resultDelete = await _degreeCompetenceRepository.UpdateAsync(result);
                    return _mapper.Map<DegreeCompetenceViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el degre competence");
            }
            catch
            {
                throw;
            }
        }

        public async Task<DegreeCompetenceViewModel> DeletePrime(int id)
        {
            try
            {
                //var result = await _degreeCompetenceRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                //if (result != null)
                //{
                //    //1.Obtener competences que se relacionan con el competence type
                //    var competences = await _degreeCompetenceRepository.GetAllAsync(x => x.CompetenceTypeId == id);
                //    //2. Obtener CSMKP asociados a esos skills
                //    foreach (var c in competences)
                //    {
                //        var csmkp = await _c_s_m_k_pRepository.GetAllAsync(x => x.CompetenceId == c.Id);
                //        //3. Eliminar  csmkp
                //        foreach (var e in csmkp)
                //            await _c_s_m_k_pRepository.DeleteAsync(e);
                //        //4.Eliminar competenceType 
                //        await _competenceTypeRepository.DeleteAsync(result);
                //    }
                //    var resultDelete = await _competenceTypeRepository.DeleteAsync(result);
                //    return _mapper.Map<CompetenceTypeViewModel>(resultDelete);
                return await Delete(id);
                
                throw new BadRequestException("No se encuentra el competence type");
            }
            catch
            {
                throw;
            }
        }

    }
}
