﻿using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Employee : BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the SecondName.
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Gets or sets the FirstSurName.
        /// </summary>
        [Required]
        public string FirstSurName { get; set; }
        /// <summary>
        /// Gets or sets the SecondLastSurName.
        /// </summary>
        [Required]
        public string SecondLastSurName { get; set; }

        /// <summary>
        /// Gets or sets the IdDepartament.
        /// </summary>
        [ForeignKey("IdDepartament")]
        public int IdDepartament { get; set; }
        public virtual  Departament Departament { get; set; }

        /// <summary>
        /// Gets or sets the IdEmployeeProfile.
        /// </summary>
        public int IdEmployeeProfile { get; set; }
        public virtual EmployeeProfile EmployeeProfile { get; set; }

        /// <summary>
        /// Gets or sets the Teamid.
        /// </summary>
        public int? IdTeam { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<EmployeeCompetence> EmployeeCompetences { get; set; }


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
