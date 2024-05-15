using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.BehaviorDictionary
{
    public class CreateBehaviorDictionaryViewModel:BaseEntityModel//BehaviorDictionaryViewModel
    {
        public int? DegreeCompetenceId { get; set; }
        public int? BehaviorId { get; set; }
    }
}
