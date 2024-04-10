using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class TechnicalSheetRepository : BaseRepository<TechnicalSheet>, ITechnicalSheetRepository
{
    public TechnicalSheetRepository(DatabaseContext context) : base(context) { }
}
