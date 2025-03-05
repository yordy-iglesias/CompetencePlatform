﻿using CompetencePlatform.Core.Common;
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
    /// Representa los Proyectos.
    /// </summary>
    public class Project : CommonEntity
    {
        
        public int TechnicalSheetId { get; set; }
        [ForeignKey("TechnicalSheetId")]
        public virtual TechnicalSheet TechnicalSheet { get; set; }
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("ProjectUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("ProjectUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }


    }
}
