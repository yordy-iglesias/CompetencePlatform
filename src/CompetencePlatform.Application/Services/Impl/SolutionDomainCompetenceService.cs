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
    public class SolutionDomainCompetenceService : ISolutionDomainCompetenceService
    {
        private readonly ISolutionDomainCompetenceRepository _solutionDomainCompetenceRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public SolutionDomainCompetenceService(ISolutionDomainCompetenceRepository solutionDomainCompetenceRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _solutionDomainCompetenceRepository = solutionDomainCompetenceRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<SolutionDomainCompetenceModel> Create(SolutionDomainCompetenceModel entity)
        {
            try
            {
                var result = await _solutionDomainCompetenceRepository.AddAsync(_mapper.Map<SolutionDomainCompetence>(entity));
                return _mapper.Map<SolutionDomainCompetenceModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SolutionDomainCompetenceModel> Delete(int id)
        {
            try
            {
                var result = await _solutionDomainCompetenceRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _solutionDomainCompetenceRepository.DeleteAsync(result);
                    return _mapper.Map<SolutionDomainCompetenceModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Solution Domain");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<SolutionDomainCompetenceModel>> Get()
        {
            try
            {
                var result = await _solutionDomainCompetenceRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<SolutionDomainCompetenceModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SolutionDomainCompetenceModel> Get(int id)
        {
            try
            {
                var result = await _solutionDomainCompetenceRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Solution Domain Competence");
                return _mapper.Map<SolutionDomainCompetenceModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<SolutionDomainCompetenceModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<SolutionDomainCompetence, bool>> where = priority == true ?
                 where = k => (k.Competence.Name.Contains(options.Search.Value)  || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Competence.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<SolutionDomainCompetence, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "competenceName":
                        order = col => col.Competence.Name;
                        break;
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                   
                }

                var obj = await _solutionDomainCompetenceRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<SolutionDomainCompetenceModel>>(obj);
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

        public async Task<SolutionDomainCompetenceModel> Update(SolutionDomainCompetenceModel entity)
        {
            try
            {
                var employee = await _solutionDomainCompetenceRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Solution Domain Competence");

                var result = await _solutionDomainCompetenceRepository.UpdateAsync(_mapper.Map<SolutionDomainCompetence>(entity));
                return _mapper.Map<SolutionDomainCompetenceModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
