using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class Competence_Skill_Motivation_Knowledge_PreferenceRepository : BaseRepository<Competence_Skill_Motivation_Knowledge_Preference>, IC_S_M_K_PRepository
{
    public Competence_Skill_Motivation_Knowledge_PreferenceRepository(DatabaseContext context) : base(context) { }
}
