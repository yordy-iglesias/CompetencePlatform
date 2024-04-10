using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class ResponsabilityRepository : BaseRepository<Responsability>, IResponsabilityRepository
{
    public ResponsabilityRepository(DatabaseContext context) : base(context) { }
}
