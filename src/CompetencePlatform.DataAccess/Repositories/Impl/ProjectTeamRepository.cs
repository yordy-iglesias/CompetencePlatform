using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class ProjectTeamRepository : BaseRepository<ProjectTeam>, IProjectTeamRepository
{
    public ProjectTeamRepository(DatabaseContext context) : base(context) { }
}
