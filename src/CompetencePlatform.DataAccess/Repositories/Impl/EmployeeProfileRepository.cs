using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class EmployeeProfileRepository : BaseRepository<EmployeeProfile>, IEmployeeProfileRepository
{
    public EmployeeProfileRepository(DatabaseContext context) : base(context) { }
}
