using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class Competence_Skill_Motivation_Knowledge_PreferenceModel:BaseEntityModel
    {
        public int? CompetenceId { get; set; }
        public string CompetenceName { get; set; }
        public int? KnowlwdgeId { get; set; }
        public  string KnowledgeName { get; set; }
        public int? PreferenceId { get; set; }
        public string PreferenceName { get; set; }
        public int? SkillId { get; set; }
        public string SkillName { get; set; }
        public int? MotivationId { get; set; }
        public string MotivationName { get; set; }
    }
}
