using CompetencePlatform.Core.Entities.Identity;
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
        [ForeignKey("CompetenceTypeId")]
        public virtual CompetenceType CompetenceType { get; set; }

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("CompetenceUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("CompetenceUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }

        public virtual ICollection<C_S_M_K_P> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
        public virtual ICollection<CompetenceDictionary> CompetenceDictionaries { get; set; }
        public virtual ICollection<EmployeeCompetence> EmployeeCompetences { get; set; }
        public virtual ICollection<SolutionDomainCompetence> SolutionDomainCompetences { get; set; }

    }
}
