using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class EmployeeCompetenceRepository : BaseRepository<EmployeeCompetence>, IEmployeeCompetenceRepository
{
    public EmployeeCompetenceRepository(DatabaseContext context) : base(context) { }
}
