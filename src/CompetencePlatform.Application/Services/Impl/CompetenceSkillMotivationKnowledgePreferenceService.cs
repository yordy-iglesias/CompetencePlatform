using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Core.DataAccess.Repositories;
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
    public class CompetenceSkillMotivationKnowledgePreferenceService : IC_S_M_K_PService
    {
        private readonly IC_S_M_K_PRepository _cSMKPRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public CompetenceSkillMotivationKnowledgePreferenceService(IC_S_M_K_PRepository cSMKPRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _cSMKPRepository = cSMKPRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<C_S_M_K_PViewModel> Create(CreateC_S_M_K_PViewModel entity)
        {
            try
            {
                var result = await _cSMKPRepository.AddAsync(_mapper.Map<Competence_Skill_Motivation_Knowledge_Preference>(entity));
                return _mapper.Map<C_S_M_K_PViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<C_S_M_K_PViewModel> Delete(int id)
        {
            try
            {
                var result = await _cSMKPRepository.GetFirstAsync(bd => bd.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _cSMKPRepository.DeleteAsync(result);
                    return _mapper.Map<C_S_M_K_PViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Skill Motivation Knowledge Preference");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<C_S_M_K_PViewModel>> Get()
        {
            try
            {
                var result = await _cSMKPRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<C_S_M_K_PViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateC_S_M_K_PViewModel> Get(int id)
        {
            try
            {
                var result = await _cSMKPRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Skill Motivation Knowledge Preference");
                return _mapper.Map<CreateC_S_M_K_PViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<C_S_M_K_PViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Competence_Skill_Motivation_Knowledge_Preference, bool>> where = priority == true ?
                 where = csmkp => (csmkp.Competence.Name.Contains(options.Search.Value) || csmkp.Skill.Name.Contains(options.Search.Value) || csmkp.Motivation.Name.Contains(options.Search.Value) || csmkp.Knowledge.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = csmkp => (csmkp.Competence.Name.Contains(options.Search.Value) || csmkp.Skill.Name.Contains(options.Search.Value) || csmkp.Motivation.Name.Contains(options.Search.Value) || csmkp.Knowledge.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && csmkp.Deleted==false);

                Expression<Func<Competence_Skill_Motivation_Knowledge_Preference, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "competenceName":
                        order = col => col.Competence.Name;
                        break;
                    case "skillName":
                        order = col => col.Skill.Name;
                        break;
                    case "motivationName":
                        order = col => col.Motivation.Name;
                        break;
                    case "preferenceName":
                        order = col => col.Preference.Name;
                        break;

                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                }

                var obj = await _cSMKPRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<C_S_M_K_PViewModel>>(obj);
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

        public async Task<C_S_M_K_PViewModel> Update(CreateC_S_M_K_PViewModel entity)
        {
            try
            {
                var competence = await _cSMKPRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (competence == null)
                    throw new BadRequestException("No se encuentra este tipo de Competence Dictionary");

                var result = await _cSMKPRepository.UpdateAsync(_mapper.Map<Competence_Skill_Motivation_Knowledge_Preference>(entity));
                return _mapper.Map<C_S_M_K_PViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<C_S_M_K_PViewModel> GetDetails(int id)
        {

            try
            {
                var result = await _cSMKPRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<C_S_M_K_PViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
