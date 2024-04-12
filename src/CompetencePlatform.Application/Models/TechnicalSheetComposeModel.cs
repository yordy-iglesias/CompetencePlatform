using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class TechnicalSheetComposeModel:BaseEntityModel
    {
       
        public int EmployeeProfileId { get; set; }
        public string  EmployeeProfileName { get; set; }
        public int Quantity { get; set; }
        public int? TechnicalSheetId { get; set; }
        
    }
}
