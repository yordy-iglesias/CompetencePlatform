using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.SolutionDomainCompetence
{
    public class SolutionDomainCompetenceViewModel : BaseEntityModel
    {
        public int? SolutionDomainId { get; set; }
        public string SolutionDomainName { get; set; }
        //public int? CompetenceId { get; set; }
        public string CompetenceName { get; set; }
    }
}
