using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.TechnicalSheet;
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
    public class TechnicalSheetService : ITechnicalSheetService
    {
        private readonly ITechnicalSheetRepository _technicalSheetRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public TechnicalSheetService(ITechnicalSheetRepository technicalSheetRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _technicalSheetRepository = technicalSheetRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<TechnicalSheetViewModel> Create(CreateTechnicalSheetViewModel entity)
        {
            try
            {
                var result = await _technicalSheetRepository.AddAsync(_mapper.Map<TechnicalSheet>(entity));
                return _mapper.Map<TechnicalSheetViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TechnicalSheetViewModel> Delete(int id)
        {
            try
            {
                var result = await _technicalSheetRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _technicalSheetRepository.DeleteAsync(result);
                    return _mapper.Map<TechnicalSheetViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Technical Sheet");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TechnicalSheetViewModel>> Get()
        {
            try
            {
                var result = await _technicalSheetRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<TechnicalSheetViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateTechnicalSheetViewModel> Get(int id)
        {
            try
            {
                var result = await _technicalSheetRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Technical Sheet");
                return _mapper.Map<CreateTechnicalSheetViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TechnicalSheetViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _technicalSheetRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<TechnicalSheetViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<TechnicalSheetViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<TechnicalSheet, bool>> where = priority == true ?
                 where = k => (k.InitialTechnicalProposal.Contains(options.Search.Value) || k.Scope.Contains(options.Search.Value) || k.SolutionDomain.Name.Contains(options.Search.Value) || k.SolutionDomain.Organization.Name.Contains(options.Search.Value) || k.Target.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.InitialTechnicalProposal.Contains(options.Search.Value)  || k.Scope.Contains(options.Search.Value) || k.SolutionDomain.Name.Contains(options.Search.Value) || k.SolutionDomain.Organization.Name.Contains(options.Search.Value) || k.Target.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<TechnicalSheet, object>> order;
                Expression<Func<TechnicalSheet, DateTime?>> orderDate;
                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;
               
                    switch (nameColumnOrder)
                    {
                        case "initialTechnicalProposal":
                            order = col => col.InitialTechnicalProposal;
                            break;
                        case "target":
                            order = col => col.Target;
                            break;
                        case "solutionDomainName":
                            order = col => col.SolutionDomain.Name;
                            break;
                        //case "projectName":
                        //    order = col => col.Project.Name;
                        //    break;
                        case "createdBy":
                            order = col => col.CreatedBy;
                            break;
                        case "updatedBy":
                            order = col => col.UpdatedBy;
                            break;
                        case "scope":
                            order = col => col.Scope;
                            break;
                       
                        case "updateOn":
                            order = col => col.UpdatedOn;
                            break;
                        default:
                            order = col => col.CreatedOn;
                            nameColumnOrder = "createdOn";
                            break;
                    }

                    var obj = await _technicalSheetRepository.GetPage(new PageInfo
                    {
                        PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                        PageSize = options.Length
                    }, where, order, sort);

                    obj.OrderColumnName = nameColumnOrder;
                    var result = _mapper.Map<DataTablePagin<TechnicalSheetViewModel>>(obj);
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

        public async Task<TechnicalSheetViewModel> Update(CreateTechnicalSheetViewModel entity)
        {
            try
            {
                var employee = await _technicalSheetRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Technical Sheet");

                var result = await _technicalSheetRepository.UpdateAsync(_mapper.Map<TechnicalSheet>(entity));
                return _mapper.Map<TechnicalSheetViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
