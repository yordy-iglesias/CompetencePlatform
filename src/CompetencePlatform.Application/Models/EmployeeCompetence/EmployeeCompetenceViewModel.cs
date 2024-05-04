using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.EmployeeCompetence
{
    public class EmployeeCompetenceViewModel : BaseEntityModel
    {
        public string EmployeeName { get; set; }
        public string CompetenceName { get; set; }
    }
}
