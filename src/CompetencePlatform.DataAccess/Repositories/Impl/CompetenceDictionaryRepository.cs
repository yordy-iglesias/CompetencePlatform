using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class CompetenceDictionaryRepository : BaseRepository<CompetenceDictionary>, ICompetenceDictionaryRepository
{
    public CompetenceDictionaryRepository(DatabaseContext context) : base(context) { }
}
