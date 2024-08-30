using CompetencePlatform.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class PreferenceType : CommonEntity
    {
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("PreferenceTypeUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("PreferenceTypeUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
