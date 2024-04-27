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
    public class ProjectTeamService : IProjectTeamService
    {
        private readonly IProjectTeamRepository _projectTeamRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public ProjectTeamService(IProjectTeamRepository projectTeamRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _projectTeamRepository = projectTeamRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<ProjectTeamModel> Create(ProjectTeamModel entity)
        {
            try
            {
                var result = await _projectTeamRepository.AddAsync(_mapper.Map<ProjectTeam>(entity));
                return _mapper.Map<ProjectTeamModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProjectTeamModel> Delete(int id)
        {
            try
            {
                var result = await _projectTeamRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _projectTeamRepository.DeleteAsync(result);
                    return _mapper.Map<ProjectTeamModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el project team");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProjectTeamModel>> Get()
        {
            try
            {
                var result = await _projectTeamRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ProjectTeamModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProjectTeamModel> Get(int id)
        {
            try
            {
                var result = await _projectTeamRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Proeject team ");
                return _mapper.Map<ProjectTeamModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<ProjectTeamModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<ProjectTeam, bool>> where = priority == true ?
                 where = k => (k.Project.Name.Contains(options.Search.Value)  || k.Team.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Project.Name.Contains(options.Search.Value) || k.Team.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<ProjectTeam, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "projectName":
                        order = col => col.Project.Name;
                        nameColumnOrder = "projectName";
                        break;
                    case "teamName":
                        order = col => col.Team.Name;
                        nameColumnOrder = "teamName";
                        break;

                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                }

                var obj = await _projectTeamRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<ProjectTeamModel>>(obj);
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

        public async Task<ProjectTeamModel> Update(ProjectTeamModel entity)
        {
            try
            {
                var employee = await _projectTeamRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Project team");

                var result = await _projectTeamRepository.UpdateAsync(_mapper.Map<ProjectTeam>(entity));
                return _mapper.Map<ProjectTeamModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
