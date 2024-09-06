using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.SkillData
{
    public static class SkillTypeGenerator
    {
        public static List<SkillType> Generate()
        {
            var skillList = new List<SkillType>
            {
                new SkillType() { Name = "Cognitiva", Description = "Habilidad Cognitiva",IsSelected=false,IsDefault=true},
                new SkillType() { Name = "Emocional", Description = "Habilidad Emocional",IsSelected=false,IsDefault=true },
                new SkillType() { Name = "Social", Description = "Habilidad Social",IsSelected=false,IsDefault=true },
                new SkillType() { Name = "Tècnica", Description = "Habilidad Tècnica",IsSelected = false, IsDefault=true }
            };
            return skillList;
        }
    }
}
