﻿using CompetencePlatform.Application.Models.EmployeeCompetence;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface IEmployeeCompetenceService : ICrudInterface<EmployeeCompetenceViewModel,CreateEmployeeCompetenceViewModel,DataTableServerSide>
    {
    }
}
