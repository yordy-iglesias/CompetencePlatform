using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.C_S_M_K_P
{
    //CSMK-Competence_Skill_Motivation_Preference
    public class C_S_M_K_PViewModel : BaseEntityModel
    {
        public string CompetenceName { get; set; }
        public string KnowledgeName { get; set; }
        public string PreferenceName { get; set; }
        public string SkillName { get; set; }
        public string MotivationName { get; set; }
    }
}
