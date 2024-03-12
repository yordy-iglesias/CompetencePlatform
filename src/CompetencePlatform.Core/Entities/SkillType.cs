using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class SkillType:CommonEntity
    {
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
