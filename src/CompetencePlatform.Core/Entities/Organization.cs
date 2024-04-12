using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Organization : CommonEntity
    {

       
        /// <summary>
		/// Gets or sets the Mision.
		/// </summary>
        [Required]
        public string Mision { get; set; }
        /// <summary>
		/// Gets or sets the Vision.
		/// </summary>
        [Required]
        public string Vision  { get; set; }
        public virtual ICollection<Departament> Departaments { get; set; } 
        public virtual ICollection<SolutionDomain> SolutionDomains { get; set; } 

        
    }
}
