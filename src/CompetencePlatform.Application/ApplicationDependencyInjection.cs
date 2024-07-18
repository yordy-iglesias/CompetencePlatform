using CompetencePlatform.Application.Common.Email;
using CompetencePlatform.Application.MappingProfiles;
using CompetencePlatform.Application.Models.CompetenceDictionary;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Application.Services.DevImpl;
using CompetencePlatform.Application.Services.Impl;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.DataAccess.Repositories.Impl;
using CompetencePlatform.Shared.Services;
using CompetencePlatform.Shared.Services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CompetencePlatform.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        services.AddScoped<ITodoListService, TodoListService>();
        services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<ITemplateService, TemplateService>();
        //Services
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBehaviorService, BehaviorService>();
        services.AddScoped<IBehaviorDictionaryService, BehaviorDictionaryService>();
        services.AddScoped<IC_S_M_K_PService, C_S_M_K_P_Service>();
        services.AddScoped<ICompetenceService, CompetenceService>();
        services.AddScoped<ICompetenceProfileService, CompetenceProfileService>();
        services.AddScoped<ICompetenceTypeService, CompetenceTypeService>();
        services.AddScoped<IDegreeCompetenceService, DegreeCompetenceService>();
        services.AddScoped<IEmployeeCompetenceService, EmployeeCompetenceService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeProfileService, EmployeeProfileService>();
        services.AddScoped<IKnowledgeService, KnowledgeService>();
        services.AddScoped<IMotivationService, MotivationService>();
        services.AddScoped<IPreferenceService, PreferenceService>();
        services.AddScoped<IPreferenceTypeService, PreferenceTypeService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IProjectTeamService, ProjectTeamService>();
        services.AddScoped<IResponsabilityService, ResponsabilityService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<ISkillTypeService, SkillTypeService>();
        services.AddScoped<ISolutionDomainCompetenceService, SolutionDomainCompetenceService>();
        services.AddScoped<ISolutionDomainService, SolutionDomainService>();
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<ITechnicalSheetService, TechnicalSheetService>();
        services.AddScoped<IDepartamentService, DepartamentService>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<ICompetenceDictionaryService, CompetenceDictionaryService>();
        services.AddScoped<ITechnicalSheetComposeService, TechnicalSheetComposeService>();
        services.AddScoped<ISolutionDomainCompetenceService, SolutionDomainCompetenceService>();


        if (env.IsDevelopment())
            services.AddScoped<IEmailService, DevEmailService>();
        else
            services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}
