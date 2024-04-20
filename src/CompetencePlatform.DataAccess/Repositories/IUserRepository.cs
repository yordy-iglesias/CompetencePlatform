using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<ApplicationUser> {
        Task<List<IdentityRole>> GetRolByIdUser(string idUser);
        Task<List<IdentityRole>> GetRols();
    }
    
}
