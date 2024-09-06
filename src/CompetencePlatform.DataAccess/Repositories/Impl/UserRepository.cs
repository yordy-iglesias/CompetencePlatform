using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserRepository(DatabaseContext context, IHttpContextAccessor httpContextAccessor) : base(context) { 
    _httpContextAccessor = httpContextAccessor;
    }
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
    public async Task<User> CurrentUser()
    {
        var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
        return await GetFirstAsync(x=>x.UserName==userName,false);
    }
}
