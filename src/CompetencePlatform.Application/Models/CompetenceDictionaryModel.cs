using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class CompetenceDictionaryModel:BaseEntityModel
    {
        
        public int? CompetenceId { get; set; }
        public string CompetenceName { get; set; }
        public int? BehaviorDictionaryId { get; set; }
        public string BehaviorDictionaryName { get; set; }
       // public List<CompetenceProfileModel> CompetenceProfiles { get; set; }
    }
}
