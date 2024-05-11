using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Skill;
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
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public SkillService(ISkillRepository skillRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
        }
        public async Task<SkillViewModel> Create(CreateSkillViewModel entity)
        {
            try
            {
                var result = await _skillRepository.AddAsync(_mapper.Map<Skill>(entity));
                return _mapper.Map<SkillViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SkillViewModel> Delete(int id)
        {
            try
            {
                var result = await _skillRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    var resultDelete = await _skillRepository.DeleteAsync(result);
                    return _mapper.Map<SkillViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el skill");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<SkillViewModel>> Get()
        {
            try
            {
                var result = await _skillRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<SkillViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateSkillViewModel> Get(int id)
        {
            try
            {
                var result = await _skillRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Skill");
                return _mapper.Map<CreateSkillViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<SkillViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<Skill, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) ||  k.SkillType.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || k.SkillType.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<Skill, object>> order;

                int columnsOrder = (int)(options.Order.FirstOrDefault()?.Column);
                string nameColumnOrder = options.Columns[columnsOrder].Name;
                SortOrder sort = options.Order.FirstOrDefault()?.Dir == "asc" ? SortOrder.Ascending : SortOrder.Descending;

                switch (nameColumnOrder)
                {
                    case "skillTypename":
                        order = col => col.SkillType.Name;
                       break;
                    case "name":
                        order = col => col.Name;
                        break;
                    default:
                        order = col => col.CreatedOn;
                        nameColumnOrder = "createdOn";
                        break;
                       
                }

                var obj = await _skillRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<SkillViewModel>>(obj);
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
                var result = await _skillRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<SkillViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _skillRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<SkillViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SkillViewModel> Update(CreateSkillViewModel entity)
        {
            try
            {
                var employee = await _skillRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);

                if (employee == null)
                    throw new BadRequestException("No se encuentra este tipo Responsability");

                var result = await _skillRepository.UpdateAsync(_mapper.Map<Skill>(entity));
                return _mapper.Map<SkillViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
