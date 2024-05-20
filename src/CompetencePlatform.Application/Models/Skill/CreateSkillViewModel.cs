using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Skill
{
    public class CreateSkillViewModel : CommonEntityModel//SkillViewModel
    {
        public int? SkillTypeId { get; set; }
        //public string SkillTypeName { get; set; }
        // public List<Competence_Skill_Motivation_Knowledge_PreferenceModel> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
    }
}
