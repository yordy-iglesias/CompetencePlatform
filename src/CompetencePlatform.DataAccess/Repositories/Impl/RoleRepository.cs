using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context) { }
    
}
