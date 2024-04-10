﻿using CompetencePlatform.Core.DataAccess.Identity;
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

        await context.Knowledges.AddRangeAsync(KnowledgeGenerator.Generate());
        await context.SkillTypes.AddRangeAsync(SkillTypeGenerator.Generate());

        await context.SaveChangesAsync();
    }
}
