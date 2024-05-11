using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.ProjectTeam
{
    public class ProjectTeamViewModel : BaseEntityModel
    {

      
        public string ProjectName { get; set; }
        public string TeamName { get; set; }
    }
}
