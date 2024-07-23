using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Role;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities.Identity;
using CompetencePlatform.Core.Utils;
namespace CompetencePlatform.Application.Services;

public interface IRoleService: ICrudInterface<RoleViewModel, DataTableServerSide>
{
    Task<RoleViewModel> Update(RoleAccess model, int id);
    Task<RoleViewModel> Create(RoleAccess model);
    Task<IEnumerable<string>> GetScreen();
    
}
