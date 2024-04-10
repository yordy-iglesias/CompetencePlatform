using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class CompetenceProfileRepository : BaseRepository<CompetenceProfile>, ICompetenceProfileRepository
{
    public CompetenceProfileRepository(DatabaseContext context) : base(context) { }
}
