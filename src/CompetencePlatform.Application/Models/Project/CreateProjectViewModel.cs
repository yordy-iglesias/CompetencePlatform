using CompetencePlatform.Application.Models.Project;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Project
{
    public class CreateProjectViewModel : ProjectViewModel
    {
        public int? TechnicalSheetId { get; set; }
        
       
    }
}
