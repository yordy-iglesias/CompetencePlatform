using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.BehaviorDictionary
{
    public class BehaviorDictionaryModel : BaseEntityModel
    {

        public string DegreeCompetenceName { get; set; }
        public string BehaviorName { get; set; }
        //public  List<CompetenceDictionaryModel> CompetenceDictionaries { get; set; }


    }
}
