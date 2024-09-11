using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface ICompetenceTypeService : ICrudInterface<CompetenceTypeViewModel, CreateCompetenceTypeViewModel, DataTableServerSide>
    {
        Task<CompetenceTypeViewModel> DeletePrime(int id);
        Task<bool> HasChildren(int id);
        Task<bool> IsUnique(string name, string value);
        Task<CompetenceTypeViewModel> Restore(int id);
    }
}
