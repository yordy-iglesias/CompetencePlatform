using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.SolutionDomain
{
    public class CreateSolutionDomainViewModel : CommonEntityModel
    {
        public int? DepartamentId { get; set; }
        
    }
}
