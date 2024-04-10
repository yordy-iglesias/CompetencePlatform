using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class CompetenceRepository : BaseRepository<Competence>, ICompetenceRepository
{
    public CompetenceRepository(DatabaseContext context) : base(context) { }
}
