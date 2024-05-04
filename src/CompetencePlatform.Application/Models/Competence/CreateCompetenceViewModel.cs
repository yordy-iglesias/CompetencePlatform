using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class CreateCompetenceViewModel : CompetenceViewModel
    {
        
        public int? CompetenceTypeId { get; set; }
       
    }
}
