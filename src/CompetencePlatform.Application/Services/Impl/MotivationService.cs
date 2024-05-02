using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Motivation;
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
    public class MotivationService : IMotivationService
    {
        private readonly IMotivationRepository _motivationRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public MotivationService(IMotivationRepository motivationRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _motivationRepository = motivationRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<MotivationModel> Create(MotivationModel entity)
        {
            try
            {
                var result = await _motivationRepository.AddAsync(_mapper.Map<Motivation>(entity));
                return _mapper.Map<MotivationModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MotivationModel> Delete(int id)
        {
            try
            {
                var result = await _motivationRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _motivationRepository.DeleteAsync(result);
                    return _mapper.Map<MotivationModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Motivation");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<MotivationModel>> Get()
        {
            try
            {
                var result = await _motivationRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<MotivationModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<MotivationModel> Get(int id)
        {
            try
            {
                var result = await  _motivationRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Motivation ");
                return _mapper.Map<MotivationModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<MotivationModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Motivation, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<Motivation, object>> order;

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

                var obj = await _motivationRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<MotivationModel>>(obj);
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
                var result = await _motivationRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<MotivationModel> Update(MotivationModel entity)
        {
            try
            {
                var employee = await _motivationRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo de Employe Profile");

                var result = await _motivationRepository.UpdateAsync(_mapper.Map<Motivation>(entity));
                return _mapper.Map<MotivationModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
