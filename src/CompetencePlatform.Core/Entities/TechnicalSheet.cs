﻿using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class TechnicalSheet : BaseEntity, IAuditedEntity
    {

        /// <summary>
        /// Gets or sets the Target.
        /// </summary>
        [Required]
        public string Target { get; set; }
        /// <summary>
        /// Gets or sets the Scope.
        /// </summary>
        [Required]
        public string Scope { get; set; }
        /// <summary>
        /// Gets or sets the InitialTechnicalProposal.
        /// </summary>
        [Required]
        public string InitialTechnicalProposal { get; set; }

        public virtual Project Project { get; set; }

        //Audited Methods

        /// <summary>
		/// Gets or sets the CreatedBy.
		/// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
		/// Gets or sets the CreatedOn.
		/// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedBy.
		/// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedOn.
		/// </summary>
        public DateTime? UpdatedOn { get; set; }
    }
}
