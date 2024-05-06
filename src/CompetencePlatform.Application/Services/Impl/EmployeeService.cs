using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.Employee;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<EmployeeViewModel> Create(CreateEmployeeViewModel entity)
        {
            try
            {
                var result = await _employeeRepository.AddAsync(_mapper.Map<Employee>(entity));
                return _mapper.Map<EmployeeViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeViewModel> Delete(int id)
        {
            try
            {
                var result = await _employeeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _employeeRepository.DeleteAsync(result);
                    return _mapper.Map<EmployeeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeViewModel>> Get()
        {
            try
            {
                var result = await _employeeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<EmployeeViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateEmployeeViewModel> Get(int id)
        {
            try
            {
                var result = await  _employeeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<CreateEmployeeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<EmployeeViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _employeeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<EmployeeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<DataTablePagin<EmployeeViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Employee, bool>> where = priority == true ?
                 where = emp => (emp.FirstName.Contains(options.Search.Value)  || emp.FirstSurName.Contains(options.Search.Value) || emp.SecondLastSurName.Contains(options.Search.Value) || emp.SecondName.Contains(options.Search.Value) || emp.Team.Name.Contains(options.Search.Value) || emp.Departament.Name.Contains(options.Search.Value) || emp.EmployeeProfile.Name.Contains(options.Search.Value)  || string.IsNullOrEmpty(options.Search.Value))
                : where = emp => (emp.FirstName.Contains(options.Search.Value) || emp.FirstSurName.Contains(options.Search.Value) || emp.SecondLastSurName.Contains(options.Search.Value) || emp.SecondName.Contains(options.Search.Value) || emp.Team.Name.Contains(options.Search.Value) || emp.Departament.Name.Contains(options.Search.Value) || emp.EmployeeProfile.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && emp.Deleted==false);

                Expression<Func<Employee, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "secondName":
                        order = col => col.SecondName;
                        break;
                    case "firstName":
                        order = col => col.FirstName;
                        break;
                    case "secondLastSurName":
                        order = col => col.SecondLastSurName;
                        break;
                    case "departamentName":
                        order = col => col.Departament.Name;
                        break;
                    case "employeeProfileName":
                        order = col => col.EmployeeProfile.Name;
                        break;
                    case "teamName":
                        order = col => col.Team.Name;
                        break;
                    case "firstSurName":
                        order = col => col.FirstSurName;
                        break;
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;

                    
                }

                var obj = await _employeeRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<EmployeeViewModel>>(obj);
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
                var result = await _employeeRepository.GetAllAsync(x => x.FirstName);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeViewModel> Update(CreateEmployeeViewModel entity)
        {
            try
            {
                var employee = await _employeeRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo de Employe Profile");

                var result = await _employeeRepository.UpdateAsync(_mapper.Map<Employee>(entity));
                return _mapper.Map<EmployeeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
