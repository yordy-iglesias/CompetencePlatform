using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(DatabaseContext context) : base(context) { }
}
