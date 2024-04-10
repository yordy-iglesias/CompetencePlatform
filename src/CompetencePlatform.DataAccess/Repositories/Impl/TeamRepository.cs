using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
    public TeamRepository(DatabaseContext context) : base(context) { }
}
