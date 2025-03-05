using CompetencePlatform.Core.Common;
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
    /// Representa las responsabilidades.
    /// </summary>
    public class Responsability:CommonEntity
    {

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("ResponsabilityUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("ResponsabilityUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        public int? CompetenceProfileId { get; set; }
        [ForeignKey("CompetenceProfileId")]
        public virtual CompetenceProfile CompetenceProfile { get; set; }

        
		

    }
}
