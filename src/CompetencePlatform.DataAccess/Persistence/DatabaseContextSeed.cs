using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.KnowledgeData;
using CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.SkillData;
using Microsoft.AspNetCore.Identity;

namespace CompetencePlatform.Core.DataAccess.Persistence;

public static class DatabaseContextSeed
{
    public static async Task SeedDatabaseAsync(DatabaseContext context, UserManager<ApplicationUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new ApplicationUser { UserName = "admin", Email = "admin@admin.com", EmailConfirmed = true };

            await userManager.CreateAsync(user, "Admin123.?");
        }

        await AddKwnoledges(context);
        await AddSkillTypes(context);


        await context.SaveChangesAsync();
    }

    private static async Task AddKwnoledges(DatabaseContext context)
    {
        var knowledges = KnowledgeGenerator.Generate();
        if (!context.Knowledges.Any())
            await context.Knowledges.AddRangeAsync(knowledges);
        else
        {
            foreach (var k in knowledges)
            {
               if( !context.Knowledges.Any(x=>x.Name==k.Name))
                    await context.Knowledges.AddAsync(k);
            }
        }
    }
    private static async Task AddSkillTypes(DatabaseContext context)
    {
        var skillTypes = SkillTypeGenerator.Generate();
        if (!context.SkillTypes.Any())
            await context.SkillTypes.AddRangeAsync(skillTypes);
        else
        {
            foreach (var skt in skillTypes)
            {
                if (!context.SkillTypes.Any(x => x.Name == skt.Name))
                    await context.SkillTypes.AddAsync(skt);
            }
        }
    }
}
