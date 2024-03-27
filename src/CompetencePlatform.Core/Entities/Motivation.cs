using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Motivation:CommonEntity
    {
        public virtual ICollection<Competence_Skill_Motivation_Knowledge_Preference> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
    }
}
