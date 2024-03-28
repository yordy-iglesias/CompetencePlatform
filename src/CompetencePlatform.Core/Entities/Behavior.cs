using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Behavior:CommonEntity
    {
        public virtual ICollection<BehaviorDictionary> BehaviourDictionaries { get; set; }
    }
}
