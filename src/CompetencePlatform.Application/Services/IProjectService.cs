using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Project;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface IProjectService:ICrudInterface<ProjectViewModel,CreateProjectViewModel,DataTableServerSide>
    {
    }
}
