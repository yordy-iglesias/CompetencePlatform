using CompetencePlatform.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    /// <summary>
    /// Representa los tipos de habilidades.
    /// </summary>
    public class SkillType:CommonEntity
    {
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("SkillTypeUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("SkillTypeUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
