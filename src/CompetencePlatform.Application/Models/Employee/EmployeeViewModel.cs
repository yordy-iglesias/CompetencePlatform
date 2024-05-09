using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Employee
{
    public class EmployeeViewModel : BaseEntityModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurName { get; set; }
        public string SecondLastSurName { get; set; }
        //public int? DepartamentId { get; set; }
        public string DepartamentName { get; set; }
        //public int? EmployeeProfileId { get; set; }
        public string EmployeeProfileName { get; set; }
        //public int? TeamId { get; set; }
        public string TeamName { get; set; }
        // public List<EmployeeCompetence> EmployeeCompetences { get; set; }

    }
}
