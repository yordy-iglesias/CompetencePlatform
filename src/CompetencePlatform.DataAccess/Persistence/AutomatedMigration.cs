﻿using CompetencePlatform.Core.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompetencePlatform.Core.DataAccess.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<DatabaseContext>();

        if (context.Database.IsSqlServer()) await context.Database.MigrateAsync();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        await DatabaseContextSeed.SeedDatabaseAsync(context, userManager);
    }
}
