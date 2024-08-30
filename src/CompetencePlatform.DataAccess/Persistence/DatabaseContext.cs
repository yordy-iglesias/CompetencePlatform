using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Entities.Identity;
using CompetencePlatform.Shared.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CompetencePlatform.Core.DataAccess.Persistence;

public class DatabaseContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    private readonly IClaimService _claimService;

    public DatabaseContext(DbContextOptions options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
    }

    public DbSet<Behavior> Behaviors { get; set; }
    public DbSet<BehaviorDictionary> BehavioursDictionaries { get; set; }
    public DbSet<Competence> Competences { get; set; }
    public DbSet<C_S_M_K_P> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
    public DbSet<CompetenceDictionary> CompetenceDictionaries { get; set; }
    public DbSet<CompetenceProfile> CompetenceProfiles { get; set; }
    public DbSet<CompetenceType> CompetenceTypes { get; set; }
    public DbSet<DegreeCompetence> DegreeCompetences { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeCompetence> EmployeeCompetences { get; set; }
    public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
    public DbSet<Knowledge> Knowledges { get; set; }
    public DbSet<Motivation> Motiviations { get; set; }
    public DbSet<Departament> Departaments { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<PreferenceType> PreferenceTypes { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTeam> ProjectTeams { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillType> SkillTypes { get; set; }
    public DbSet<SolutionDomain> SolutionDomains { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TechnicalSheet> TechnicalSheets { get; set; }

    

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();

    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    //entry.Entity.CreatedBy = _claimService.GetUserId()==0?Users.FirstOrDefault(x=>x.UserName== "developer")?.Id : _claimService.GetUserId();
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    //entry.Entity.UpdatedBy = _claimService.GetUserId() == 0 ? Users.FirstOrDefault(x => x.UserName == "developer").Id : _claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
