using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<User> {
        Task<User> CurrentUser();
        Task<List<Role>> GetRolByIdUser(int idUser);

    }
    
}
