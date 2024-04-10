using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class BehaviorDictionaryRepository : BaseRepository<BehaviorDictionary>, IBehaviorDictionaryRepository
{
    public BehaviorDictionaryRepository(DatabaseContext context) : base(context) { }
}
