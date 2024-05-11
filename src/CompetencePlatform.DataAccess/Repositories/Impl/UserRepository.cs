using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }
    public async Task<List<IdentityRole>> GetRolByIdUser(string idUser)
    {
        var rols = new List<string>();
        var rolsList = new List<IdentityRole>();

        rols.AddRange(Context.UserRoles.Where(x => x.UserId.Equals(idUser)).Select(x => x.RoleId));

        foreach (var rol in rols)
        {
            rolsList.AddRange(Context.Roles.Where(x => x.Id == rol));
        }
        //var rolsDB = Context.Roles.Where(x => x.Id == rols[0]).ToListAsync();
        return rolsList;
    }
}
