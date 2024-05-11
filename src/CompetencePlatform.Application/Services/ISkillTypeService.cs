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
    public interface ISkillTypeService:ICrudInterface<SkillTypeViewModel,CreateSkillTypeViewModel,DataTableServerSide>
    {
    }
}
