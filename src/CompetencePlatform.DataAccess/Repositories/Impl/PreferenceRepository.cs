using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class PreferenceRepository : BaseRepository<Preference>, IPreferenceRepository
{
    public PreferenceRepository(DatabaseContext context) : base(context) { }
}
