using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class StudyPlanRepository : GenericRepository<StudyPlan>, IStudyPlan
    {
        public StudyPlanRepository(ApplicationContext Context) : base(Context)
        {
        }
    }
}
