using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class CompetenceTypeRepository : BaseRepository<CompetenceType>, ICompetenceTypeRepository
{
    public CompetenceTypeRepository(DatabaseContext context) : base(context) { }
}
