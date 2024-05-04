using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.EmployeeCompetence
{
    public class CreateEmployeeCompetenceViewModel : EmployeeCompetenceViewModel
    {

        public int? EmployeeId { get; set; }
        public int? CompetenceId { get; set; }
       
    }
}
