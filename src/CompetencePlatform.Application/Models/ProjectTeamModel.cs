using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class ProjectTeamModel:BaseEntityModel
    {
       
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
