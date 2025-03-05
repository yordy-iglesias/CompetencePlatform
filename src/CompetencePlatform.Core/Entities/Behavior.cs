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
    /// Entidad que refelfa los comportamientos 
    /// </summary>
    public class Behavior:CommonEntity
    {
        public virtual ICollection<BehaviorDictionary> BehaviorDictionaries { get; set; }
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("BehaviorUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("BehaviorUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
    }
}
