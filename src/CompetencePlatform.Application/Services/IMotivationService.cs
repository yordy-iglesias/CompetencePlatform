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
    public interface IMotivationService : ICrudInterface<MotivationViewModel,CreateMotivationViewModel,DataTableServerSide>
    {
    }
}
