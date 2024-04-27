using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
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
    public class CompetenceDictionaryService : ICompetenceDictionaryService
    {
        private readonly ICompetenceDictionaryRepository _competenceDictionaryRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public CompetenceDictionaryService(ICompetenceDictionaryRepository competenceDictionaryRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _competenceDictionaryRepository = competenceDictionaryRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<CompetenceDictionaryModel> Create(CompetenceDictionaryModel entity)
        {
            try
            {
                var result = await _competenceDictionaryRepository.AddAsync(_mapper.Map<CompetenceDictionary>(entity));
                return _mapper.Map<CompetenceDictionaryModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompetenceDictionaryModel> Delete(int id)
        {
            try
            {
                var result = await _competenceDictionaryRepository.GetFirstAsync(bd => bd.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _competenceDictionaryRepository.DeleteAsync(result);
                    return _mapper.Map<CompetenceDictionaryModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompetenceDictionaryModel>> Get()
        {
            try
            {
                var result = await _competenceDictionaryRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<CompetenceDictionaryModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompetenceDictionaryModel> Get(int id)
        {
            try
            {
                var result = await _competenceDictionaryRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<CompetenceDictionaryModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<CompetenceDictionaryModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<CompetenceDictionary, bool>> where = priority == true ?
                 where = cd => (cd.Competence.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = cd => (cd.Competence.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value)&& cd.Deleted==false);

                Expression<Func<CompetenceDictionary, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "competenceName":
                        order = col => col.Competence.Name;
                        break;
                   
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                }

                var obj = await _competenceDictionaryRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<CompetenceDictionaryModel>>(obj);
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

        public async Task<CompetenceDictionaryModel> Update(CompetenceDictionaryModel entity)
        {
            try
            {
                var competenceDictionary = await _competenceDictionaryRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (competenceDictionary == null)
                    throw new BadRequestException("No se encuentra este tipo de Competence Dictionary");

                var result = await _competenceDictionaryRepository.UpdateAsync(_mapper.Map<CompetenceDictionary>(entity));
                return _mapper.Map<CompetenceDictionaryModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
