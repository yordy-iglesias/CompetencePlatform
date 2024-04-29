using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.EmployeeCompetence;
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
using System.Runtime.Intrinsics.Arm;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services.Impl
{
    public class EmployeeCompetenceService : IEmployeeCompetenceService
    {
        private readonly IEmployeeCompetenceRepository _employeeCompetenceRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public EmployeeCompetenceService(IEmployeeCompetenceRepository employeeCompetenceRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _employeeCompetenceRepository = employeeCompetenceRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<EmployeeCompetenceModel> Create(EmployeeCompetenceModel entity)
        {
            try
            {
                var result = await _employeeCompetenceRepository.AddAsync(_mapper.Map<EmployeeCompetence>(entity));
                return _mapper.Map<EmployeeCompetenceModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeCompetenceModel> Delete(int id)
        {
            try
            {
                var result = await _employeeCompetenceRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _employeeCompetenceRepository.DeleteAsync(result);
                    return _mapper.Map<EmployeeCompetenceModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeCompetenceModel>> Get()
        {
            try
            {
                var result = await _employeeCompetenceRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<EmployeeCompetenceModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeCompetenceModel> Get(int id)
        {
            try
            {
                var result = await  _employeeCompetenceRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<EmployeeCompetenceModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<EmployeeCompetenceModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<EmployeeCompetence, bool>> where = priority == true ?
                 where = ecm => (ecm.Competence.Name.Contains(options.Search.Value) || ecm.Employee.FirstName.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = ecm => (ecm.Competence.Name.Contains(options.Search.Value) || ecm.Employee.FirstName.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && ecm.Deleted == false) ;

                Expression<Func<EmployeeCompetence, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "employeeName":
                        order = col => col.Employee.FirstName;
                        nameColumnOrder = "employeeName";
                        break;
                    case "competenceName":
                        order = col => col.Competence.Name;
                        nameColumnOrder = "employeeName";
                        break;

                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;

                }

                var obj = await _employeeCompetenceRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<EmployeeCompetenceModel>>(obj);
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

        public async Task<EmployeeCompetenceModel> Update(EmployeeCompetenceModel entity)
        {
            try
            {
                var employeeCompetence = await _employeeCompetenceRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employeeCompetence == null)
                    throw new BadRequestException("No se encuentra este tipo de Departament");

                var result = await _employeeCompetenceRepository.UpdateAsync(_mapper.Map<EmployeeCompetence>(entity));
                return _mapper.Map<EmployeeCompetenceModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
