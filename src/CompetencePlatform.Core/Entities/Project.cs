using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public  class Project : CommonEntity
    {
        
        public int? TechnicalSheetId { get; set; }
        public virtual TechnicalSheet TechnicalSheet { get; set; }

        
    }
}
