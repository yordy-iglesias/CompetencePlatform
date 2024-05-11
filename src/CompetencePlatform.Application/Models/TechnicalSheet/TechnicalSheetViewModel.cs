using CompetencePlatform.Application.Models.TechnicalSheetCompose;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.TechnicalSheet
{
    public class TechnicalSheetViewModel : BaseEntityModel
    {

        public string Target { get; set; }
        public string Scope { get; set; }
        public string InitialTechnicalProposal { get; set; }
        public string ProjectName { get; set; }
        //public int? SolutionDomainId { get; set; }
        public string SolutionDomainName { get; set; }
        public List<TechnicalSheetComposeViewModel> TechnicalSheetComposes { get; set; }
    }
}
