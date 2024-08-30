using CompetencePlatform.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Knowledge : CommonEntity
    {
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("KnowledgeUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("KnowledgeUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        public virtual ICollection<C_S_M_K_P> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
    }
}
