using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.KnowledgeData;
using CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.SkillData;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Entities.Identity;
using CompetencePlatform.Core.Enums;
using CompetencePlatform.Core.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CompetencePlatform.Core.DataAccess.Persistence;

public static class DatabaseContextSeed
{
    public static async Task SeedDatabaseAsync(DatabaseContext context, UserManager<User> userManager, RoleManager<Role> roleManager,IConfiguration configuration,IOrganizationRepository organizationRepository,ISkillTypeRepository skillTypeRepository,IKnowledgeRepository knowledgeRepository )
    {
        var organization=await AddDefaultOrganization(organizationRepository);
        if (organization != null)
        {
            foreach (var roleName in Enum.GetNames(typeof(SystemRoleEnum)))
            {
                int priority = 0;
                switch (roleName)
                {
                    case "Admin":
                        priority = 1;
                        break;
                    case "Developer":
                        priority = 0;
                        break;
                    default:
                        priority = 2;break;
                }
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var role = new Role(roleName,roleName);
                    if (roleName.Equals(SystemRoleEnum.Admin.ToString()) || roleName.Equals(SystemRoleEnum.Developer.ToString()))
                    {
                        RoleAccess newRol = new RoleAccess
                        {
                            RolName = roleName,
                            Permisions = new List<Permission>()
                        };

                        foreach (var module in Enum.GetNames(typeof(ModuleEnum)))
                        {
                            var modulePermission = new Permission { screenName = module };
                            var actions = new List<string>();

                            foreach (var permission in Enum.GetNames(typeof(PermissionEnum)))
                            {
                                actions.Add(permission);
                            }
                            modulePermission.Actions = actions;
                            newRol.Permisions.Add(modulePermission);
                        }

                        string stamp = JwtHelper.GenerateRoleToken(newRol, configuration);

                        role.ConcurrencyStamp = stamp;
                        

                    }
                    role.Priority= priority;
                    await roleManager.CreateAsync(role);
                }
            }
            var admin = new User();
            var developer = new User();
            var employee = new User();
            if (!userManager.Users.Any())
            {
                admin = new User { UserName = "admin", Email = "admin@admin.com", EmailConfirmed = true ,OrganizacionId=organization.Id};
                developer = new User { UserName = "developer", Email = "developer@developer.com", EmailConfirmed = true, OrganizacionId = organization.Id };
                employee = new User { UserName = "employee", Email = "employee@employee.com", EmailConfirmed = true, OrganizacionId = organization.Id };
                await userManager.CreateAsync(admin, "Admin123.?");
                await userManager.CreateAsync(developer, "Developer123.?");
                await userManager.CreateAsync(employee, "Employee123.?");

                await userManager.AddToRoleAsync(admin, SystemRoleEnum.Admin.ToString());
                await userManager.AddToRoleAsync(developer, SystemRoleEnum.Developer.ToString());
                await userManager.AddToRoleAsync(employee, SystemRoleEnum.Employee.ToString());
            }
            await context.SaveChangesAsync();
            await SeedKwnoledges(knowledgeRepository);
            await SeedSkillTypes(skillTypeRepository);
        }
       
    }
    private static async Task<Organization> AddDefaultOrganization(IOrganizationRepository organizationRepository)
    {
        var defaultOrganization = new Organization() { 
            IsSelected = true,
            Name = "default",
            Mision = "default",
            Vision = "default",
            Description= "default",
            Deleted = false,
            Address = "default",
            City = "default",
            Country = "default",
            Email = "default@default.com",
            IsDefault = true,
            LogoUrl = "default",
            Phone = "default",
            QuantityEmployeesByTemplate=0,
            Sector=SectorTypeEnum.Tecnology,
            Type=OrganizationTypeEnum.Public,
            WebSiteAddress= "https://default.com"

            
        };
        try
        {
            if (!(await organizationRepository.GetAllAsync()).Any())
            {
                return await organizationRepository.AddAsync(defaultOrganization);

            }
        }
        catch (Exception ex)
        {

            throw;
        }
        

        return null;
       
    }
    private static async Task SeedKwnoledges(IKnowledgeRepository knowledgeRepository)
    {
        var knowledges = KnowledgeGenerator.Generate();
        foreach (var k in knowledges)
            {
               if((await knowledgeRepository.GetFirstAsync(x => x.Name == k.Name,false))==null)
                    await knowledgeRepository.AddAsync(k);
            }
        
    }

    private static async Task SeedSkillTypes(ISkillTypeRepository skillTypeRepository)
    {
        var skillTypes = SkillTypeGenerator.Generate();
        foreach (var skt in skillTypes)
            {
                if (await skillTypeRepository.GetFirstAsync(x => x.Name == skt.Name,false)==null)
                     await skillTypeRepository.AddAsync(skt);
            }
    }
    
}
