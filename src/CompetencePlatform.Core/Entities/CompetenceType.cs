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
    /// Entidad que representa el Tipo de Competencia.
    /// </summary>
    public class CompetenceType:CommonEntity
    {
        public virtual  ICollection<Competence> Competences { get; set; }
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("CompetenceTypeUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("CompetenceTypeUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
    }
}
