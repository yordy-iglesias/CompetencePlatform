using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class OrganizationModel:CommonEntityModel
    {
        
        public string Mision { get; set; }
       
        public string Vision { get; set; }
       // public List<DepartamentModel> Departaments { get; set; }
        //public List<SolutionDomainModel> SolutionDomains { get; set; }
    }
}
