using CompetencePlatform.Application.Models.TechnicalSheet;
using CompetencePlatform.Application.Models.TechnicalSheetCompose;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface ITechnicalSheetService : ICrudInterface<TechnicalSheetViewModel, CreateTechnicalSheetViewModel, DataTableServerSide>
    {
    }
}
