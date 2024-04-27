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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public TeamService(ITeamRepository teamRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<TeamModel> Create(TeamModel entity)
        {
            try
            {
                var result = await _teamRepository.AddAsync(_mapper.Map<Team>(entity));
                return _mapper.Map<TeamModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeamModel> Delete(int id)
        {
            try
            {
                var result = await _teamRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _teamRepository.DeleteAsync(result);
                    return _mapper.Map<TeamModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el team");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TeamModel>> Get()
        {
            try
            {
                var result = await _teamRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<TeamModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TeamModel> Get(int id)
        {
            try
            {
                var result = await _teamRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Team");
                return _mapper.Map<TeamModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<TeamModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Team, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<Team, object>> order;

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

                var obj = await _teamRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<TeamModel>>(obj);
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
                var result = await _teamRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TeamModel> Update(TeamModel entity)
        {
            try
            {
                var employee = await _teamRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Solution Domain");

                var result = await _teamRepository.UpdateAsync(_mapper.Map<Team>(entity));
                return _mapper.Map<TeamModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
