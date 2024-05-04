using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
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
    public class BehaviorDictionaryService : IBehaviorDictionaryService
    {
        private readonly IBehaviorDictionaryRepository _behaviorDictionaryRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public BehaviorDictionaryService(IBehaviorDictionaryRepository behaviorDictionaryRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _behaviorDictionaryRepository = behaviorDictionaryRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<BehaviorDictionaryViewModel> Create(CreateBehaviorDictionaryViewModel entity)
        {
            try
            {
                var result = await _behaviorDictionaryRepository.AddAsync(_mapper.Map<BehaviorDictionary>(entity));
                return _mapper.Map<BehaviorDictionaryViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BehaviorDictionaryViewModel> Delete(int id)
        {
            try
            {
                var result = await _behaviorDictionaryRepository.GetFirstAsync(bd => bd.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _behaviorDictionaryRepository.DeleteAsync(result);
                    return _mapper.Map<BehaviorDictionaryViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Behavior Dictionary");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<BehaviorDictionaryViewModel>> Get()
        {
            try
            {
                var result = await _behaviorDictionaryRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<BehaviorDictionaryViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateBehaviorDictionaryViewModel> Get(int id)
        {
            try
            {
                var result = await _behaviorDictionaryRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Behavior Dictionary");
                return _mapper.Map<CreateBehaviorDictionaryViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async  Task<BehaviorDictionaryViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _behaviorDictionaryRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<BehaviorDictionaryViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<BehaviorDictionaryViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<BehaviorDictionary, bool>> where = priority == true ?
                 where = bd => (bd.Behavior.Name.Contains(options.Search.Value) || bd.DegreeCompetence.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = bd => (bd.Behavior.Name.Contains(options.Search.Value) || bd.DegreeCompetence.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value)&& bd.Deleted==false);

                Expression<Func<BehaviorDictionary, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "behaviourName":
                        order = col => col.Behavior.Name;
                        break;
                    case "degreeCompetenceName":
                        order = col => col.DegreeCompetence.Name;
                        break;
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                }

                var obj = await _behaviorDictionaryRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<BehaviorDictionaryViewModel>>(obj);
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

        public async Task<BehaviorDictionaryViewModel> Update(CreateBehaviorDictionaryViewModel entity)
        {
            try
            {
                var behaviorDictionary = await _behaviorDictionaryRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (behaviorDictionary == null)
                    throw new BadRequestException("No se encuentra este tipo de Behaviour Dictionary");

                var result = await _behaviorDictionaryRepository.UpdateAsync(_mapper.Map<BehaviorDictionary>(entity));
                return _mapper.Map<BehaviorDictionaryViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        
    }
}
