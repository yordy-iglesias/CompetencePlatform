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
                new SkillType() { Name = "Cognitiva", Description = "Habilidad Cognitiva" },
                new SkillType() { Name = "Emocional", Description = "Habilidad Emocional" },
                new SkillType() { Name = "Social", Description = "Habilidad Social" },
                new SkillType() { Name = "Tècnica", Description = "Habilidad Tècnica" }
            };
            return skillList;
        }
    }
}
