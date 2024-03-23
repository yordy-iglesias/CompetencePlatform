using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class SolutionDomainCompetence:BaseEntity, IAuditedEntity
    {

        /// <summary>
        /// Gets or sets the IdSolutionDomain.
        /// </summary>
        [ForeignKey("IdSolutionDomain")]
        public int IdSolutionDomain { get; set; }
        public virtual SolutionDomain SolutionDomain { get; set; }
        /// <summary>
        /// Gets or sets the IdCompetence.
        /// </summary>
        [ForeignKey("IdCompetence")]
        public int IdCompetence { get; set; }
        public virtual Competence Competence { get; set; }


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
