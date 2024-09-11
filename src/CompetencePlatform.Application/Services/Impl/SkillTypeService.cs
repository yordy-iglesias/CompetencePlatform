using AutoMapper;
using CompetencePlatform.Application.Exceptions;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Resposability;
using CompetencePlatform.Application.Models.SkillType;
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
    public class SkillTypeService : ISkillTypeService
    {
        private readonly ISkillTypeRepository _skillTypeRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IC_S_M_K_PRepository _c_s_m_k_pRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IUserRepository _userRepository;
        public SkillTypeService(IC_S_M_K_PRepository c_s_m_k_pRepository,ISkillRepository skillRepository,ISkillTypeRepository skillTypeRepository, IMapper mapper, IClaimService claimService, IUserRepository userRepository)
        {
            _skillTypeRepository = skillTypeRepository;
            _mapper = mapper;
            _claimService = claimService;
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _c_s_m_k_pRepository = c_s_m_k_pRepository;
        }
        public async Task<SkillTypeViewModel> Create(CreateSkillTypeViewModel entity)
        {
            try
            {
                entity.IsDefault = false;
                entity.IsSelected = true;
                entity.Deleted = false;
                entity.CreatedBy=(await _userRepository.CurrentUser()).Id;
                var result = await _skillTypeRepository.AddAsync(_mapper.Map<SkillType>(entity));
                return _mapper.Map<SkillTypeViewModel>(result);
            }   
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SkillTypeViewModel> Delete(int id)
        {
            try
            {
                var result = await _skillTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                result.Deleted = true;
                if (result != null)
                {
                    var resultDelete = await _skillTypeRepository.UpdateAsync(result);
                    return _mapper.Map<SkillTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el skill type");
            }
            catch
            {
                throw;
            }
        }
        public async Task<SkillTypeViewModel> Restore(int id)
        {
            try
            {
                var result = await _skillTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                result.Deleted = false;
                if (result != null)
                {
                    var resultDelete = await _skillTypeRepository.UpdateAsync(result);
                    return _mapper.Map<SkillTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el skill type");
            }
            catch
            {
                throw;
            }
        }
        public async Task<SkillTypeViewModel> DeletePrime(int id)
        {
            try
            {
                var result = await _skillTypeRepository.GetFirstAsync(dc => dc.Id == id, asNoTracking: false);
                if (result != null)
                {
                    //1.Obtener skills que se relacionan con el skill type
                    var skills=await _skillRepository.GetAllAsync(x=>x.SkillTypeId==id );
                    //2. Obtener CSMKP asociados a esos skills
                    foreach (var skill in skills)
                    {
                        var csmkp= await _c_s_m_k_pRepository.GetAllAsync(x => x.SkillId == skill.Id);
                        //3. Eliminar  csmkp
                       foreach(var e in csmkp)
                            await _c_s_m_k_pRepository.DeleteAsync(e);
                       //4.Eliminar skill 
                       await _skillRepository.DeleteAsync(skill);
                    }
                    var resultDelete = await _skillTypeRepository.DeleteAsync(result);
                    return _mapper.Map<SkillTypeViewModel>(resultDelete);
                }
                throw new BadRequestException("No se encuentra el skill type");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<SkillTypeViewModel>> Get()
        {
            try
            {
                var result = await _skillTypeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<SkillTypeViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CreateSkillTypeViewModel> Get(int id)
        {
            try
            {
                var result = await _skillTypeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este Skill Type");
                return _mapper.Map<CreateSkillTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SkillTypeViewModel> GetDetails(int id)
        {
            try
            {
                var result = await _skillTypeRepository.GetFirstAsync(x => x.Id == id, asNoTracking: true);
                if (result == null)
                    throw new BadRequestException("No existe este elemento");
                return _mapper.Map<SkillTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTablePagin<SkillTypeViewModel>> GetPagination(DataTableServerSide options)
        {
            try
            {
                var currentUserId = _claimService.GetUserId();
                if (currentUserId == null)
                    throw new BadRequestException("No se encuentra un usuario vàlido");
                var user = await _userRepository.GetFirstAsync(x => x.Id == currentUserId, asNoTracking: true);
                string username = user.UserName;
                var priority = (await _userRepository.GetRolByIdUser(currentUserId)).Any(x => x.NormalizedName == "ADMIN" || x.NormalizedName == "DEVELOPER");

                Expression<Func<SkillType, bool>> where = priority == true ?
                 where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value))
                : where = k => (k.Name.Contains(options.Search.Value) || string.IsNullOrEmpty(options.Search.Value) && k.Deleted==false);

                Expression<Func<SkillType, object>> order;

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

                var obj = await _skillTypeRepository.GetPage(new PageInfo
                {
                    PageNumber = options.Start == 0 ? 1 : (options.Start / options.Length) + 1,
                    PageSize = options.Length
                }, where, order, sort);

                obj.OrderColumnName = nameColumnOrder;
                var result = _mapper.Map<DataTablePagin<SkillTypeViewModel>>(obj);
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
                var result = await _skillTypeRepository.GetAllAsync(x => x.Name);
                return _mapper.Map<IEnumerable<SelectViewModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SkillTypeViewModel> Update(CreateSkillTypeViewModel entity)
        {
            try
            {
                var skillType = await _skillTypeRepository.GetFirstAsync(x => x.Id == entity.Id, asNoTracking: true);
                entity.UpdatedBy= (await _userRepository.CurrentUser()).Id;
                if (skillType == null)
                    throw new BadRequestException("No se encuentra este tipo Skill type");

                var result = await _skillTypeRepository.UpdateAsync(_mapper.Map<SkillType>(entity));
                return _mapper.Map<SkillTypeViewModel>(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> IsUnique(string name, string value)
        {
            try
            {
                Expression<Func<SkillType, bool>> where;
                switch (name)
                {
                    case "name":
                        where = s => s.Name == value;
                        break;
                    default:

                        return false;
                }

                var obj = await _skillTypeRepository.GetFirstAsync(where, false);
                return obj == null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool>HasChildren(int id)
        {
            var result = await _skillRepository.GetFirstAsync(x => x.SkillTypeId == id,false);
            return result != null;
        }
    }
}
