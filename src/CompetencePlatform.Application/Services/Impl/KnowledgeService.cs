using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.Knowledge;
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
    public class KnowledgeService : IKnowledgeService
    {
        private readonly IKnowledgeRepository _knowledgeRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public KnowledgeService(IKnowledgeRepository knowledgeRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _knowledgeRepository = knowledgeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<KnowledgeViewModel> Create(CreateKnowledgeViewModel entity)
        {
            try
            {
                var result = await _knowledgeRepository.AddAsync(_mapper.Map<Knowledge>(entity));
                return _mapper.Map<KnowledgeViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<KnowledgeViewModel> Delete(int id)
        {
            try
            {
                var result = await _knowledgeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _knowledgeRepository.DeleteAsync(result);
                    return _mapper.Map<KnowledgeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<KnowledgeViewModel>> Get()
        {
            try
            {
                var result = await _knowledgeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<KnowledgeViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateKnowledgeViewModel> Get(int id)
        {
            try
            {
                var result = await  _knowledgeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<CreateKnowledgeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<KnowledgeViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _knowledgeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<KnowledgeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<KnowledgeViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Knowledge, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<Knowledge, object>> order;

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

                var obj = await _knowledgeRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<KnowledgeViewModel>>(obj);
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
                var result = await _knowledgeRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<KnowledgeViewModel> Update(CreateKnowledgeViewModel entity)
        {
            try
            {
                var employee = await _knowledgeRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo de Employe Profile");

                var result = await  _knowledgeRepository.UpdateAsync(_mapper.Map<Knowledge>(entity));
                return _mapper.Map<KnowledgeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
