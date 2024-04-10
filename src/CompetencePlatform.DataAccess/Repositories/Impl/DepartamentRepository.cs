using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class DepartamentRepository : BaseRepository<Departament>, IDepartamentRepository
{
    public DepartamentRepository(DatabaseContext context) : base(context) { }
}
