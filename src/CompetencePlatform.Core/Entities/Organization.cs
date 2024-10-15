using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.Enums;
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
        [Required]
        public OrganizationTypeEnum Type { get; set; }
        [Required]
        public SectorTypeEnum Sector { get; set; }
        //Ubication
        public string Address {  get; set; }
        public string City {  get; set; }
        public string Country {  get; set; }
        public string Phone {  get; set; }
        public string Email {  get; set; }
        public string WebSiteAddress {  get; set; }
        //Qauntities
        public int QuantityEmployeesByTemplate {  get; set; }
        


        /// <summary>
		/// Gets or sets the Vision.
		/// </summary>
        [Required]
        public string Vision  { get; set; }
        public virtual ICollection<Departament> Departaments { get; set; } 
        //public virtual ICollection<SolutionDomain> SolutionDomains { get; set; } 

        
    }
}
