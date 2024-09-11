using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface IPreferenceTypeService : ICrudInterface<PreferenceTypeViewModel, CreatePreferenceTypeViewModel, DataTableServerSide>
    {
        Task<PreferenceTypeViewModel> DeletePrime(int id);
        Task<bool> HasChildren(int id);
        Task<bool> IsUnique(string name, string value);
        Task<PreferenceTypeViewModel> Restore(int id);
    }
}
