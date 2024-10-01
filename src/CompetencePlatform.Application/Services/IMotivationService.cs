using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface IMotivationService : ICrudInterface<MotivationViewModel, CreateMotivationViewModel, DataTableServerSide>
    {
        Task<MotivationViewModel> DeletePrime(int id);
        Task<bool> HasChildren(int id);
        Task<bool> IsUnique(string name, string value);
        Task<MotivationViewModel> Restore(int id);
    }
}
