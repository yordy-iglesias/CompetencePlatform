﻿using CompetencePlatform.Application.Models.ProjectTeam;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class CreateProjectTeamViewModel : BaseEntityModel
    {
        public int? ProjectId { get; set; }
        public int? TeamId { get; set; }
       
    }
}
