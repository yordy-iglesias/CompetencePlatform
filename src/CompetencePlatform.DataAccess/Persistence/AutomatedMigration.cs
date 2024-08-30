using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompetencePlatform.Core.DataAccess.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services, IConfiguration configuration)
    {
        var context = services.GetRequiredService<DatabaseContext>();

        if (context.Database.IsSqlServer()) await context.Database.MigrateAsync();

        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<Role>>();
        var organizationRepository = services.GetRequiredService<IOrganizationRepository>();
        var skillTypeRepository = services.GetRequiredService<ISkillTypeRepository>();
        var knowledgeRepository = services.GetRequiredService<IKnowledgeRepository>();
        await DatabaseContextSeed.SeedDatabaseAsync(context, userManager,roleManager, configuration,organizationRepository,skillTypeRepository,knowledgeRepository);
    }
}
