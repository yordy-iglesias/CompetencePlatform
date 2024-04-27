using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class SolutionDomainCompetenceRepository : BaseRepository<SolutionDomainCompetence>, ISolutionDomainCompetenceRepository
{
    public SolutionDomainCompetenceRepository(DatabaseContext context) : base(context) { }
}
