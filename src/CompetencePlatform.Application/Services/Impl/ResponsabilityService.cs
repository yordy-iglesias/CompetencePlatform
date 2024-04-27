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
    public class ResponsabilityService : IResponsabilityService
    {
        private readonly IResponsabilityRepository _responsabilityRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public ResponsabilityService(IResponsabilityRepository responsabilityRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _responsabilityRepository = responsabilityRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<ResponsabilityModel> Create(ResponsabilityModel entity)
        {
            try
            {
                var result = await _responsabilityRepository.AddAsync(_mapper.Map<Responsability>(entity));
                return _mapper.Map<ResponsabilityModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponsabilityModel> Delete(int id)
        {
            try
            {
                var result = await _responsabilityRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _responsabilityRepository.DeleteAsync(result);
                    return _mapper.Map<ResponsabilityModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el responsability");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ResponsabilityModel>> Get()
        {
            try
            {
                var result = await _responsabilityRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ResponsabilityModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponsabilityModel> Get(int id)
        {
            try
            {
                var result = await _responsabilityRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Responsability");
                return _mapper.Map<ResponsabilityModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<ResponsabilityModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Responsability, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value)  || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value)  || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<Responsability, object>> order;

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

                var obj = await _responsabilityRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<ResponsabilityModel>>(obj);
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

        public async Task<ResponsabilityModel> Update(ResponsabilityModel entity)
        {
            try
            {
                var employee = await _responsabilityRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Responsability");

                var result = await _responsabilityRepository.UpdateAsync(_mapper.Map<Responsability>(entity));
                return _mapper.Map<ResponsabilityModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
