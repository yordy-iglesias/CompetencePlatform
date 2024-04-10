using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class TechnicalSheetComposeRepository : BaseRepository<TechnicalSheetCompose>, ITechnicalSheetComposeRepository
{
    public TechnicalSheetComposeRepository(DatabaseContext context) : base(context) { }
}
