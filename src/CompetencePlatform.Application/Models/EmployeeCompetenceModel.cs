using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class EmployeeCompetenceModel:BaseEntityModel
    {
       
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? CompetenceId { get; set; }
        public string CompetenceName { get; set; }
    }
}
