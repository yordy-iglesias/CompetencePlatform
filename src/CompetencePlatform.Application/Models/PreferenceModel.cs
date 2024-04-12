using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class PreferenceModel:CommonEntityModel
    {
        
        public int? PreferenceTypeId { get; set; }
        public string PreferenceTypeName { get; set; }
        //public List<Competence_Skill_Motivation_Knowledge_Preference> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
    }
}
