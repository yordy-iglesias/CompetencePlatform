using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.CompetenceProfile
{
    public class CreateCompetenceProfileViewModel : CompetenceProfileViewModel
    {

        public int? CompetenceDictionaryId { get; set; }
        public int? EmployeeProfileId { get; set; }
      

    }
}
