using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class BehaviorRepository : BaseRepository<Behavior>, IBehaviorRepository
{
    public BehaviorRepository(DatabaseContext context) : base(context) { }
}
