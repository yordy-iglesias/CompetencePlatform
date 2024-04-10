using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class SkillTypeRepository : BaseRepository<SkillType>, ISkillTypeRepository
{
    public SkillTypeRepository(DatabaseContext context) : base(context) { }
}
