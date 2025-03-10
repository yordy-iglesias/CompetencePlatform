﻿using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Shared.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CompetencePlatform.Core.DataAccess.Persistence;

public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    private readonly IClaimService _claimService;

    public DatabaseContext(DbContextOptions options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
    }

    public DbSet<Behaviour> Behaviours { get; set; }
    public DbSet<BehaviourDictionary> BehavioursDictionaries { get; set; }
    public DbSet<Competence> Competences { get; set; }
    public DbSet<Competence_Skill_Motivation_Knowledge_Preference> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
    public DbSet<CompetenceDictionary> CompetenceDictionaries { get; set; }
    public DbSet<CompetenceProfile> CompetenceProfiles { get; set; }
    public DbSet<CompetenceType> CompetenceTypes { get; set; }
    public DbSet<DegreeCompetence> DegreeCompetences { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeCompetence> EmployeeCompetences { get; set; }
    public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
    public DbSet<Knowledge> Knowledges { get; set; }
    public DbSet<Motiviation> Motiviations { get; set; }
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


    //public DbSet<TodoItem> TodoItems { get; set; }

    //public DbSet<TodoList> TodoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //Configuracion uno a uno con Project y TecnicalSheet
        builder.Entity<Project>()
            .HasOne(b => b.TechnicalSheet)
            .WithOne(ts => ts.Project)
            .HasForeignKey<Project>(p => p.IdTechnicalSheet);
        base.OnModelCreating(builder);

    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _claimService.GetUserId();
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
