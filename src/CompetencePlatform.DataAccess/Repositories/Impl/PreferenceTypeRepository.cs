using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class PreferenceTypeRepository : BaseRepository<PreferenceType>, IPreferenceTypeRepository
{
    public PreferenceTypeRepository(DatabaseContext context) : base(context) { }
}
