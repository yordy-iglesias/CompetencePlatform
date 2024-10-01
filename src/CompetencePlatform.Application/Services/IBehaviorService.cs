using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface IBehaviorService : ICrudInterface<BehaviorViewModel, CreateBehaviorViewModel, DataTableServerSide>
    {
        Task<BehaviorViewModel> DeletePrime(int id);
        Task<bool> HasChildren(int id);
        Task<bool> IsUnique(string name, string value);
        Task<BehaviorViewModel> Restore(int id);
    }
}
