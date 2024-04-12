using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Departament : CommonEntity
    {
        /// <summary>
        /// Gets or sets the IdOrganization.
        /// </summary>
        
        public int? OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual  ICollection<Employee> Employees { get; set; }
       

        
    }
}
