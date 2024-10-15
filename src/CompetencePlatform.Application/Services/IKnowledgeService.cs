using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface IKnowledgeService : ICrudInterface<KnowledgeViewModel, CreateKnowledgeViewModel, DataTableServerSide>
    {
        Task<KnowledgeViewModel> DeletePrime(int id);
        Task<bool> HasChildren(int id);
        Task<bool> IsUnique(string name, string value);
        Task<KnowledgeViewModel> Restore(int id);
    }
}
