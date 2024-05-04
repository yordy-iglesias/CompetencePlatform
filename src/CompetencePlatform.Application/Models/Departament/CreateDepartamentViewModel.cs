using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Departament
{
    public class CreateDepartamentViewModel : DepartamentViewModel
    {
        public int? OrganizationId { get; set; }
        
    }
}
