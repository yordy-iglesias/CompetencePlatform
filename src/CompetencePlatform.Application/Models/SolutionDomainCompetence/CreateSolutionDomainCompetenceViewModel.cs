using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.SolutionDomainCompetence
{
    public class CreateSolutionDomainCompetenceViewModel : SolutionDomainCompetenceViewModel
    {
        public int? SolutionDomainId { get; set; }
        public int? CompetenceId { get; set; }
        
    }
}
