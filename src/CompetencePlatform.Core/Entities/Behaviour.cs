using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Behaviour:CommonEntity
    {
        public virtual ICollection<BehaviourDictionary> BehaviourDictionaries { get; set; }
    }
}
