using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class DegreeCompetenceRepository : BaseRepository<DegreeCompetence>, IDegreeCompetenceRepository
{
    public DegreeCompetenceRepository(DatabaseContext context) : base(context) { }
}
