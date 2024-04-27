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
    public class CompetenceService : ICompetenceService
    {
        private readonly ICompetenceRepository _competenceRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public CompetenceService(ICompetenceRepository competenceRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _competenceRepository = competenceRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<CompetenceModel> Create(CompetenceModel entity)
        {
            try
            {
                var result = await _competenceRepository.AddAsync(_mapper.Map<Competence>(entity));
                return _mapper.Map<CompetenceModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompetenceModel> Delete(int id)
        {
            try
            {
                var result = await _competenceRepository.GetFirstAsync(bd => bd.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _competenceRepository.DeleteAsync(result);
                    return _mapper.Map<CompetenceModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el Competence Dictionary ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompetenceModel>> Get()
        {
            try
            {
                var result = await _competenceRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<CompetenceModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompetenceModel> Get(int id)
        {
            try
            {
                var result = await _competenceRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este tipo de Competence Dictionary ");
                return _mapper.Map<CompetenceModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<CompetenceModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Competence, bool>> where = priority == true ?
                 where = cp => (cp.Name.Contains(options.Search.Value) || cp.CompetenceType.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = cp => (cp.Name.Contains(options.Search.Value) || cp.CompetenceType.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value)&& cp.Deleted==false);

                Expression<Func<Competence, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "name":
                        order = col => col.Name;
                        break;
                    case "competenceTypeName":
                        order = col => col.CompetenceType.Name;
                        break;

                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                }

                var obj = await _competenceRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<CompetenceModel>>(obj);
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
                var result = await _competenceRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompetenceModel> Update(CompetenceModel entity)
        {
            try
            {
                var competence = await _competenceRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (competence == null)
                    throw new BadRequestException("No se encuentra este tipo de Competence Dictionary");

                var result = await _competenceRepository.UpdateAsync(_mapper.Map<Competence>(entity));
                return _mapper.Map<CompetenceModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
