using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrganizacionId { get; set; }
        [ForeignKey("OrganizacionId")]
        public virtual Organization Organization { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Deleted { get; set; }
        public int ScreenAutoLockMinutes { get; set; }
        public string CultureId { get; set; } = "";
        public string TimeZoneId { get; set; } = "";
        public string AvatarUrl { get; set; } = "";
        public bool IsActive { get; set; }

        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Behavior> BehaviorUserCreatedBy { get; set; }
        public virtual ICollection<Behavior> BehaviorUserUpdatedBy { get; set; }
        public virtual ICollection<BehaviorDictionary> BehaviorDictionaryUserCreatedBy { get; set; }
        public virtual ICollection<BehaviorDictionary> BehaviorDictionaryUserUpdatedBy { get; set; }
        public virtual ICollection<C_S_M_K_P> CSMKUserCreatedBy { get; set; }
        public virtual ICollection<C_S_M_K_P> CSMKUserUpdatedBy { get; set; }
        public virtual ICollection<Competence> CompetenceUserCreatedBy { get; set; }
        public virtual ICollection<Competence> CompetenceUserUpdatedBy { get; set; }
        public virtual ICollection<CompetenceDictionary> CompetenceDictionaryUserCreatedBy { get; set; }
        public virtual ICollection<CompetenceDictionary> CompetenceDictionaryUserUpdatedBy { get; set; }
        public virtual ICollection<CompetenceProfile> CompetenceProfileUserCreatedBy { get; set; }
        public virtual ICollection<CompetenceProfile> CompetenceProfileUserUpdatedBy { get; set; }
        public virtual ICollection<CompetenceType> CompetenceTypeUserCreatedBy { get; set; }
        public virtual ICollection<CompetenceType> CompetenceTypeUserUpdatedBy { get; set; }
        public virtual ICollection<DegreeCompetence> DegreeCompetenceUserCreatedBy { get; set; }
        public virtual ICollection<DegreeCompetence> DegreeCompetenceUserUpdatedBy { get; set; }
        public virtual ICollection<Departament> DepartamentUserCreatedBy { get; set; }
        public virtual ICollection<Departament> DepartamentUserUpdatedBy { get; set; }
        public virtual ICollection<Employee> EmployeeUserCreatedBy { get; set; }
        public virtual ICollection<Employee> EmployeeUserUpdatedBy { get; set; }
        public virtual ICollection<EmployeeCompetence> EmployeeCompetenceUserCreatedBy { get; set; }
        public virtual ICollection<EmployeeCompetence> EmployeeCompetenceUserUpdatedBy { get; set; }
        public virtual ICollection<EmployeeProfile> EmployeeProfileUserCreatedBy { get; set; }
        public virtual ICollection<EmployeeProfile> EmployeeProfileUserUpdatedBy { get; set; }
        public virtual ICollection<Knowledge> KnowledgeUserCreatedBy { get; set; }
        public virtual ICollection<Knowledge> KnowledgeUserUpdatedBy { get; set; }
        public virtual ICollection<Motivation> MotivationUserCreatedBy { get; set; }
        public virtual ICollection<Motivation> MotivationUserUpdatedBy { get; set; }
        public virtual ICollection<Preference> PreferenceUserCreatedBy { get; set; }
        public virtual ICollection<Preference> PreferenceUserUpdatedBy { get; set; }
        public virtual ICollection<PreferenceType> PreferenceTypeUserCreatedBy { get; set; }
        public virtual ICollection<PreferenceType> PreferenceTypeUserUpdatedBy { get; set; }
        public virtual ICollection<Project> ProjectUserCreatedBy { get; set; }
        public virtual ICollection<Project> ProjectUserUpdatedBy { get; set; }
        public virtual ICollection<ProjectTeam> ProjectTeamUserCreatedBy { get; set; }
        public virtual ICollection<ProjectTeam> ProjectTeamUserUpdatedBy { get; set; }
        public virtual ICollection<Responsability> ResponsabilityUserCreatedBy { get; set; }
        public virtual ICollection<Responsability> ResponsabilityUserUpdatedBy { get; set; }
        public virtual ICollection<Skill> SkillUserCreatedBy { get; set; }
        public virtual ICollection<Skill> SkillUserUpdatedBy { get; set; }
        public virtual ICollection<SkillType> SkillTypeUserCreatedBy { get; set; }
        public virtual ICollection<SkillType> SkillTypeUserUpdatedBy { get; set; }
        public virtual ICollection<SolutionDomain> SolutionDomainUserCreatedBy { get; set; }
        public virtual ICollection<SolutionDomain> SolutionDomainUserUpdatedBy { get; set; }
        public virtual ICollection<SolutionDomainCompetence> SolutionDomainCompetenceUserCreatedBy { get; set; }
        public virtual ICollection<SolutionDomainCompetence> SolutionDomainCompetenceUserUpdatedBy { get; set; }
        public virtual ICollection<Team> TeamUserCreatedBy { get; set; }
        public virtual ICollection<Team> TeamUserUpdatedBy { get; set; }
        public virtual ICollection<TechnicalSheet> TechnicalSheetUserCreatedBy { get; set; }
        public virtual ICollection<TechnicalSheet> TechnicalSheetUserUpdatedBy { get; set; }
        public virtual ICollection<TechnicalSheetCompose> TechnicalSheetComposeUserCreatedBy { get; set; }
        public virtual ICollection<TechnicalSheetCompose> TechnicalSheetComposeUserUpdatedBy { get; set; }
        public virtual ICollection<Organization> OrganizationUserUpdatedBy { get; set; }
    }
}




