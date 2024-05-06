using CompetencePlatform.Application.Models.EmployeeProfile;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface IEmployeeProfileService:ICrudInterface<EmployeeProfileViewModel,CreateEmployeeProfileViewModel,DataTableServerSide>
    {
    }
}
