using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Competence:CommonEntity
    {
        /// <summary>
        /// Gets or sets the CompetenceTypeId.
        /// </summary>
        public int? CompetenceTypeId { get; set; }
        public virtual CompetenceType CompetenceType { get; set; }

        public virtual ICollection<Competence_Skill_Motivation_Knowledge_Preference> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
        public virtual ICollection<CompetenceDictionary> CompetenceDictionaries { get; set; }
        public virtual ICollection<EmployeeCompetence> EmployeeCompetences { get; set; }
        public ICollection<SolutionDomainCompetence> SolutionDomainCompetences { get; set; }

    }
}
