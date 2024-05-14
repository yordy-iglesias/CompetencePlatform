using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Behaviour
{
    public class BehaviorViewModel : CommonEntityModel
    {
       public List<BehaviorDictionaryViewModel> BehaviorDictionaries { get; set; }
    }
}
