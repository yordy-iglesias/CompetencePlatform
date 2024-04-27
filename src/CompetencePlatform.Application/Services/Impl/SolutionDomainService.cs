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
    public class SolutionDomainService : ISolutionDomainService
    {
        private readonly ISolutionDomainRepository _solutionDomainRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public SolutionDomainService(ISolutionDomainRepository solutionDomainRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _solutionDomainRepository = solutionDomainRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<SolutionDomainModel> Create(SolutionDomainModel entity)
        {
            try
            {
                var result = await _solutionDomainRepository.AddAsync(_mapper.Map<SolutionDomain>(entity));
                return _mapper.Map<SolutionDomainModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SolutionDomainModel> Delete(int id)
        {
            try
            {
                var result = await _solutionDomainRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _solutionDomainRepository.DeleteAsync(result);
                    return _mapper.Map<SolutionDomainModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el skill type");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<SolutionDomainModel>> Get()
        {
            try
            {
                var result = await _solutionDomainRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<SolutionDomainModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SolutionDomainModel> Get(int id)
        {
            try
            {
                var result = await _solutionDomainRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este SolutionDomain");
                return _mapper.Map<SolutionDomainModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<SolutionDomainModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<SolutionDomain, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) || k.Organization.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || k.Organization.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<SolutionDomain, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    
                    case "organizationName":
                        order = col => col.Organization.Name;
                        break;
                    case "name":
                        order = col => col.Name;
                        break;
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                   
                }

                var obj = await _solutionDomainRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<SolutionDomainModel>>(obj);
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
                var result = await _solutionDomainRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SolutionDomainModel> Update(SolutionDomainModel entity)
        {
            try
            {
                var employee = await _solutionDomainRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Solution Domain");

                var result = await _solutionDomainRepository.UpdateAsync(_mapper.Map<SolutionDomain>(entity));
                return _mapper.Map<SolutionDomainModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
