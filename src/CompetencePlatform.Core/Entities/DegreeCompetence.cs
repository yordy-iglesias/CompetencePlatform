using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    /// <summary>
    /// Representa el grado de competencia de cada competencia.
    /// </summary>
    public class DegreeCompetence :CommonEntity
    {
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("DegreeCompetenceUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("DegreeCompetenceUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        public virtual ICollection<BehaviorDictionary> BehaviourDictionaries { get; set; }
    }
}
