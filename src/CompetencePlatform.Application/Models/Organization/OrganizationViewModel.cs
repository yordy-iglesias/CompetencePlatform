using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Organization
{
    public class OrganizationViewModel : CommonEntityModel
    {

        public string Mision { get; set; }

        public string Vision { get; set; }
        [Required]
        public int Type { get; set; }
        public string TypeName { get; set; }
        public string SectorTypeName { get; set; }
        [Required]
        public int Sector { get; set; }
        //Ubication
        public string Address { get; set; }
        public int City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSiteAddress { get; set; }
        //Quantities
        public int QuantityEmployeesByTemplate { get; set; }
        public int QuantityDepartament { get; set; }
        public int QuantityEmployees { get; set; }
        public int QuantityEmployeProfiles { get; set; }
        public int TemplateCoverage { get; set; }

    }
}
