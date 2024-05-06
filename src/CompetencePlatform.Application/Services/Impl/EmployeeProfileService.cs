using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.EmployeeProfile;
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
    public class EmployeeProfileService : IEmployeeProfileService
    {
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public EmployeeProfileService(IEmployeeProfileRepository employeeProfileRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _employeeProfileRepository = employeeProfileRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<EmployeeProfileViewModel> Create(CreateEmployeeProfileViewModel entity)
        {
            try
            {
                var result = await _employeeProfileRepository.AddAsync(_mapper.Map<EmployeeProfile>(entity));
                return _mapper.Map<EmployeeProfileViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeProfileViewModel> Delete(int id)
        {
            try
            {
                var result = await _employeeProfileRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _employeeProfileRepository.DeleteAsync(result);
                    return _mapper.Map<EmployeeProfileViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeProfileViewModel>> Get()
        {
            try
            {
                var result = await _employeeProfileRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<EmployeeProfileViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateEmployeeProfileViewModel> Get(int id)
        {
            try
            {
                var result = await  _employeeProfileRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<CreateEmployeeProfileViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeProfileViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _employeeProfileRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<EmployeeProfileViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<EmployeeProfileViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<EmployeeProfile, bool>> where = priority == true ?
                 where = emp => (emp.SolutionDomain.Name.Contains(options.Search.Value)  || string.IsNullOrEmpty(options.Search.Value))
                : where = emp => (emp.SolutionDomain.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && emp.Deleted == false) ;

                Expression<Func<EmployeeProfile, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "solutionName":
                        order = col => col.SolutionDomain.Name;
                        nameColumnOrder = "employeeName";
                        break;

                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;

                  
                }

                var obj = await _employeeProfileRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<EmployeeProfileViewModel>>(obj);
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

        public async Task<EmployeeProfileViewModel> Update(CreateEmployeeProfileViewModel entity)
        {
            try
            {
                var employeeProfile = await _employeeProfileRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employeeProfile == null)
                    throw new BadRequestException("No se encuentra este tipo de Employe Profile");

                var result = await _employeeProfileRepository.UpdateAsync(_mapper.Map<EmployeeProfile>(entity));
                return _mapper.Map<CreateEmployeeProfileViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
