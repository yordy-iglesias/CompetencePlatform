using CompetencePlatform.Application.Models.SkillType;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface ISkillTypeService : ICrudInterface<SkillTypeViewModel, CreateSkillTypeViewModel, DataTableServerSide>
    {
        Task<SkillTypeViewModel> DeletePrime(int id);
        Task<bool> HasChildren(int id);
        Task<bool> IsUnique(string name, string value);
        Task<SkillTypeViewModel> Restore(int id);
    }
}
