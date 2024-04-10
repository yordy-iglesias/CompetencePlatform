using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class KnowledgeRepository : BaseRepository<Knowledge>, IKnowledgeRepository
{
    public KnowledgeRepository(DatabaseContext context) : base(context) { }
}
