using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class DepartamentModel:CommonEntityModel
    {
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        //public List<EmployeeModel> Employees { get; set; }
    }
}
