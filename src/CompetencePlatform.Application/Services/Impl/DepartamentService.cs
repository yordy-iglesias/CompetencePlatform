using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Departament;
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
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public DepartamentService(IDepartamentRepository departamentRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _departamentRepository = departamentRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<DepartamentModel> Create(DepartamentModel entity)
        {
            try
            {
                var result = await _departamentRepository.AddAsync(_mapper.Map<Departament>(entity));
                return _mapper.Map<DepartamentModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DepartamentModel> Delete(int id)
        {
            try
            {
                var result = await _departamentRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _departamentRepository.DeleteAsync(result);
                    return _mapper.Map<DepartamentModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<DepartamentModel>> Get()
        {
            try
            {
                var result = await _departamentRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<DepartamentModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DepartamentModel> Get(int id)
        {
            try
            {
                var result = await  _departamentRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<DepartamentModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<DepartamentModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Departament, bool>> where = priority == true ?
                 where = dp => (dp.Name.Contains(options.Search.Value) || dp.Organization.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = dp => (dp.Name.Contains(options.Search.Value) || dp.Organization.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value)&& dp.Deleted==false);

                Expression<Func<Departament, object>> order;

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

                var obj = await _departamentRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<DepartamentModel>>(obj);
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
                var result = await _departamentRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DepartamentModel> Update(DepartamentModel entity)
        {
            try
            {
                var competence = await _departamentRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (competence == null)
                    throw new BadRequestException("No se encuentra este tipo de Departament");

                var result = await _departamentRepository.UpdateAsync(_mapper.Map<Departament>(entity));
                return _mapper.Map<DepartamentModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
