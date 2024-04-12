using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class CompetenceModel:CommonEntityModel
    {
        
        public int? CompetenceTypeId { get; set; }
        public string CompetenceTypeName { get; set; }

        //public List<Competence_Skill_Motivation_Knowledge_PreferenceModel> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
        //public List<CompetenceDictionaryModel> CompetenceDictionaries { get; set; }
        //public List<EmployeeCompetenceModel> EmployeeCompetences { get; set; }
        //public List<SolutionDomainCompetenceModel> SolutionDomainCompetences { get; set; }
    }
}
