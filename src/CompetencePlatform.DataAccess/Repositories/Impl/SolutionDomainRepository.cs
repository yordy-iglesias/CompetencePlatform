using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class SolutionDomainRepository : BaseRepository<SolutionDomain>, ISolutionDomainRepository
{
    public SolutionDomainRepository(DatabaseContext context) : base(context) { }
}
