using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Organization;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.DataAccess.Repositories.Impl;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Enums;
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
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public OrganizationService(IEmployeeRepository employeeRepository,IEmployeeProfileRepository employeeProfileRepository, IOrganizationRepository organizationRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _organizationRepository = organizationRepository;
            _employeeProfileRepository = employeeProfileRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<OrganizationViewModel> Create(CreateOrganizationViewModel entity)
        {
            try
            {
                var result = await _organizationRepository.AddAsync(_mapper.Map<Organization>(entity));
                return _mapper.Map<OrganizationViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OrganizationViewModel> Delete(int id)
        {
            try
            {
                var result = await _organizationRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _organizationRepository.DeleteAsync(result);
                    return _mapper.Map<OrganizationViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra la organization");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrganizationViewModel>> Get()
        {
            try
            {
                var result = await _organizationRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<OrganizationViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateOrganizationViewModel> Get(int id)
        {
            try
            {
                var result = await  _organizationRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Motivation ");
                return _mapper.Map<CreateOrganizationViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<CreateOrganizationViewModel> GetDefaultOrganization()
        {
            try
            {
                var organization = (await _organizationRepository.GetAllAsync()).FirstOrDefault();
                if (organization == null)
                    throw new BadRequestException("No existe este tipo de Organization");
                var result= _mapper.Map<CreateOrganizationViewModel>(organization);
                result.QuantityEmployeProfiles=await _employeeProfileRepository.Count();
                result.QuantityEmployees=await _employeeRepository.Count();
                result.TemplateCoverage=(result.QuantityEmployees != 0 && organization.QuantityEmployeesByTemplate!=0)?(result.QuantityEmployees/organization.QuantityEmployeesByTemplate ) *100:0;
                return _mapper.Map<CreateOrganizationViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public Task<OrganizationViewModel> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataTablePagin<OrganizationViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Organization, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) || k.Mision.Contains(options.Search.Value) || k.Vision.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || k.Mision.Contains(options.Search.Value) || k.Vision.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<Organization, object>> order;

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

                var obj = await _organizationRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<OrganizationViewModel>>(obj);
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
                var result = await _organizationRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<SelectViewModel>>GetOrganizationSectorTypes()
        {
            Array values = Enum.GetValues(typeof(SectorTypeEnum));
            List<SelectViewModel> items = new List<SelectViewModel>(values.Length);
            foreach (var i in values)
            {
                SelectViewModel item = new SelectViewModel
                {
                    Text = Enum.GetName(typeof(SectorTypeEnum), i),
                    Value = (int)i
                };
                items.Add(item);
            }
            return items;
        }

        public async Task<OrganizationViewModel> Update(CreateOrganizationViewModel entity)
        {
            try
            {
                var organization = await _organizationRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (organization == null)
                    throw new BadRequestException("No se encuentra este tipo de Employe Profile");
                entity.UpdatedOn = DateTime.Now;
                entity.UpdatedBy = (await _userRepository.CurrentUser())?.Id;
                var org = _mapper.Map<Organization>(entity);
                var result = await _organizationRepository.UpdateAsync(_mapper.Map<Organization>(entity));
                return _mapper.Map<OrganizationViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<SelectViewModel>> GetCities()
        {
            Array values = Enum.GetValues(typeof(CitiesEnum));
            List<SelectViewModel> items = new List<SelectViewModel>(values.Length);
            foreach (var i in values)
            {
                SelectViewModel item = new SelectViewModel
                {
                    Text = Enum.GetName(typeof(CitiesEnum), i).Replace("_"," "),
                    Value = (int)i
                };
                items.Add(item);
            }
            return items;
        }
    }
}
