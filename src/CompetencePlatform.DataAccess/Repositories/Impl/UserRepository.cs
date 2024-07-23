using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }
    public async Task<List<Role>> GetRolByIdUser(int idUser)
    {
        var rols = new List<int>();
        var rolsList = new List<Role>();

        rols.AddRange(Context.UserRoles.Where(x => x.UserId == idUser).Select(x => x.RoleId));

        foreach (var rol in rols)
        {
            rolsList.AddRange(Context.Roles.Where(x => x.Id == rol));
        }
        return rolsList;
    }
}
