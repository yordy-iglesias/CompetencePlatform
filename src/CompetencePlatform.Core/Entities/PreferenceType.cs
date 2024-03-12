using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class PreferenceType : CommonEntity
    {
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
