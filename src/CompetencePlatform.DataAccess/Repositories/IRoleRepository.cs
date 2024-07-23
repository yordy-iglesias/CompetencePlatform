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
    public interface IRoleRepository : IBaseRepository<Role> {
        
    }
    
}
