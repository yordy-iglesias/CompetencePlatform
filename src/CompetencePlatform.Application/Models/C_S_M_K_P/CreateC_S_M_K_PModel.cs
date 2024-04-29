using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.C_S_M_K_P
{
    //CSMK-Competence_Skill_Motivation_Preference
    public class CreateC_S_M_K_PModel : C_S_M_K_PModel
    {
        public int? CompetenceId { get; set; }
        public int? KnowlwdgeId { get; set; }
        public int? PreferenceId { get; set; }
        public int? SkillId { get; set; }
        public int? MotivationId { get; set; }

    }
}
