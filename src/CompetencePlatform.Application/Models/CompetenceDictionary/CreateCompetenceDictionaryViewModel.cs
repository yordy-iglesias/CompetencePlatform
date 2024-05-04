using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.CompetenceDictionary
{
    public class CreateCompetenceDictionaryViewModel : CompetenceDictionaryViewModel
    {

        public int? CompetenceId { get; set; }
        public int? BehaviorDictionaryId { get; set; }

        // public List<CompetenceProfileModel> CompetenceProfiles { get; set; }
    }
}
