using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class MotivationRepository : BaseRepository<Motivation>, IMotivationRepository
{
    public MotivationRepository(DatabaseContext context) : base(context) { }
}
