using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class CompetenceProfileModel:BaseEntityModel
    {
        
        public int? CompetenceDictionaryId { get; set; }
        public int? EmployeeProfileId { get; set; }
        // public  List<ResponsabilityModel> Responsabilities { get; set; }

    }
}
