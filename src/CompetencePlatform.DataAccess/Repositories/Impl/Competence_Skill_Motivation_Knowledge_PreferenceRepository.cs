using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class Competence_Skill_Motivation_Knowledge_PreferenceRepository : BaseRepository<Competence_Skill_Motivation_Knowledge_Preference>, ICompetence_Skill_Motivation_Knowledge_PreferenceRepository
{
    public Competence_Skill_Motivation_Knowledge_PreferenceRepository(DatabaseContext context) : base(context) { }
}
