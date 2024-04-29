using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.CompetenceProfile;
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
    public class CompetenceProfileService : ICompetenceProfileService
    {
        private readonly ICompetenceProfileRepository _competenceProfileRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public CompetenceProfileService(ICompetenceProfileRepository CompetenceProfileRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _competenceProfileRepository = CompetenceProfileRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<CompetenceProfileModel> Create(CompetenceProfileModel entity)
        {
            try
            {
                var result = await _competenceProfileRepository.AddAsync(_mapper.Map<CompetenceProfile>(entity));
                return _mapper.Map<CompetenceProfileModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompetenceProfileModel> Delete(int id)
        {
            try
            {
                var result = await _competenceProfileRepository.GetFirstAsync(bd => bd.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _competenceProfileRepository.DeleteAsync(result);
                    return _mapper.Map<CompetenceProfileModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompetenceProfileModel>> Get()
        {
            try
            {
                var result = await _competenceProfileRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<CompetenceProfileModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompetenceProfileModel> Get(int id)
        {
            try
            {
                var result = await _competenceProfileRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<CompetenceProfileModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<CompetenceProfileModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<CompetenceProfile, bool>> where = priority == true ?
                 where = cp => (cp.EmployeeProfile.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = cp => (cp.EmployeeProfile.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value)&& cp.Deleted==false);

                Expression<Func<CompetenceProfile, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "employeeProfileName":
                        order = col => col.EmployeeProfile.Name;
                        break;
                   
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                }

                var obj = await _competenceProfileRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<CompetenceProfileModel>>(obj);
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

        public async Task<CompetenceProfileModel> Update(CompetenceProfileModel entity)
        {
            try
            {
                var CompetenceProfile = await _competenceProfileRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (CompetenceProfile == null)
                    throw new BadRequestException("No se encuentra este tipo de Competence Dictionary");

                var result = await _competenceProfileRepository.UpdateAsync(_mapper.Map<CompetenceProfile>(entity));
                return _mapper.Map<CompetenceProfileModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
