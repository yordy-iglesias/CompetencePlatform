using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class DegreeCompetence :CommonEntity
    {

        public virtual ICollection<BehaviorDictionary> BehaviourDictionaries { get; set; }
    }
}
