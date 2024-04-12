using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public  class Responsability:CommonEntity
    {
        
        public int? CompetenceProfileId { get; set; }
        public virtual CompetenceProfile CompetenceProfile { get; set; }

        
		

    }
}
