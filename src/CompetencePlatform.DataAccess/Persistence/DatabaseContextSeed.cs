using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.KnowledgeData;
using CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.SkillData;
using CompetencePlatform.Core.Entities.Identity;
using CompetencePlatform.Core.Enums;
using CompetencePlatform.Core.Utils;
using Microsoft.AspNetCore.Identity;

namespace CompetencePlatform.Core.DataAccess.Persistence;

public static class DatabaseContextSeed
{
    public static async Task SeedDatabaseAsync(DatabaseContext context, UserManager<User> userManager, RoleManager<Role> roleManager, Microsoft.Extensions.Configuration.IConfiguration configuration)
    {

        foreach (var roleName in Enum.GetNames(typeof(SystemRoleEnum)))
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var role = new Role(roleName);
                if (roleName.Equals(SystemRoleEnum.Admin.ToString()) || roleName.Equals(SystemRoleEnum.Developer.ToString() ) )
                {
                    RoleAccess newRol = new RoleAccess
                    {
                        RolName = roleName,
                        Accesses = new List<Access>()
                    };

                    foreach (var module in Enum.GetNames(typeof(ModuleEnum)))
                    {
                        var modulePermission = new Access { screenName = module };
                        var actions = new List<string>();

                        foreach (var permission in Enum.GetNames(typeof(PermissionEnum)))
                        {
                            actions.Add(permission);
                        }
                        modulePermission.Actions = actions;
                        newRol.Accesses.Add(modulePermission);
                    }

                    string stamp = JwtHelper.GenerateRoleToken(newRol, configuration);

                    role.ConcurrencyStamp = stamp;
                }
                await roleManager.CreateAsync(role);
            }
        }
        var admin = new User(); 
        var developer = new User();
        var employee = new User();
        if (!userManager.Users.Any())
        {
            admin = new User { UserName = "admin", Email = "admin@admin.com", EmailConfirmed = true };
            developer = new User { UserName = "developer", Email = "developer@developer.com", EmailConfirmed = true };
            employee = new User { UserName = "employee", Email = "employee@employee.com", EmailConfirmed = true };
            await userManager.CreateAsync(admin, "Admin123.?");
            await userManager.CreateAsync(developer, "Developer123.?");
            await userManager.CreateAsync(employee, "Employee123.?");

            await userManager.AddToRoleAsync(admin, SystemRoleEnum.Admin.ToString());
            await userManager.AddToRoleAsync(developer, SystemRoleEnum.Developer.ToString());
            await userManager.AddToRoleAsync(employee, SystemRoleEnum.Employee.ToString());
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
