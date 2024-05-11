using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.DataAccess.Repositories.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompetencePlatform.Core.DataAccess;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddIdentity();

        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        services.AddScoped<ITodoListRepository, TodoListRepository>();
        services.AddScoped<IBehaviorDictionaryRepository, BehaviorDictionaryRepository>();
        services.AddScoped<IBehaviorRepository, BehaviorRepository>();
        services.AddScoped<IC_S_M_K_PRepository, Competence_Skill_Motivation_Knowledge_PreferenceRepository>();
        services.AddScoped<ICompetenceDictionaryRepository, CompetenceDictionaryRepository>();
        services.AddScoped<ICompetenceProfileRepository, CompetenceProfileRepository>();
        services.AddScoped<ICompetenceRepository, CompetenceRepository>();
        services.AddScoped<ICompetenceTypeRepository, CompetenceTypeRepository>();
        services.AddScoped<IDegreeCompetenceRepository, DegreeCompetenceRepository>();
        services.AddScoped<IDepartamentRepository, DepartamentRepository>();
        services.AddScoped<IEmployeeCompetenceRepository, EmployeeCompetenceRepository>();
        services.AddScoped<IEmployeeProfileRepository, EmployeeProfileRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IKnowledgeRepository, KnowledgeRepository>();
        services.AddScoped<IMotivationRepository, MotivationRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IPreferenceRepository, PreferenceRepository>();
        services.AddScoped<IPreferenceTypeRepository, PreferenceTypeRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectTeamRepository, ProjectTeamRepository>();
        services.AddScoped<IResponsabilityRepository, ResponsabilityRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<ISkillTypeRepository, SkillTypeRepository>();
        services.AddScoped<ISolutionDomainRepository, SolutionDomainRepository>();
        services.AddScoped<ISolutionDomainCompetenceRepository, SolutionDomainCompetenceRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITechnicalSheetComposeRepository, TechnicalSheetComposeRepository>();
        services.AddScoped<ITechnicalSheetRepository, TechnicalSheetRepository>();
       
       
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

        if (databaseConfig.UseInMemoryDatabase)
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("NTierDatabase");
                options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
        else
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(databaseConfig.ConnectionString,
                    opt => opt.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
    }

    private static void AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<DatabaseContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
    }
}

// TODO move outside?
public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }

    public string ConnectionString { get; set; }
}
