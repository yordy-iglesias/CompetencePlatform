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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<ProjectModel> Create(ProjectModel entity)
        {
            try
            {
                var result = await _projectRepository.AddAsync(_mapper.Map<Project>(entity));
                return _mapper.Map<ProjectModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProjectModel> Delete(int id)
        {
            try
            {
                var result = await _projectRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _projectRepository.DeleteAsync(result);
                    return _mapper.Map<ProjectModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra la preferencia");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProjectModel>> Get()
        {
            try
            {
                var result = await _projectRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ProjectModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProjectModel> Get(int id)
        {
            try
            {
                var result = await _projectRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Preferencia ");
                return _mapper.Map<ProjectModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<ProjectModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Project, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value)  || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<Project, object>> order;

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

                var obj = await _projectRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<ProjectModel>>(obj);
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
                var result = await _projectRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProjectModel> Update(ProjectModel entity)
        {
            try
            {
                var employee = await _projectRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo de  Preference");

                var result = await _projectRepository.UpdateAsync(_mapper.Map<Project>(entity));
                return _mapper.Map<ProjectModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
