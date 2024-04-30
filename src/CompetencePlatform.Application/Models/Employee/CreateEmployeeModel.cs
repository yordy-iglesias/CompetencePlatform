using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Employee
{
    public class CreateEmployeeModel : EmployeeModel
    {
        public int? DepartamentId { get; set; }
        public int? EmployeeProfileId { get; set; }
        public int? TeamId { get; set; }
       
    }
}
