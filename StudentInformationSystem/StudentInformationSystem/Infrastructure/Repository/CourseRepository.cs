using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourse
    {
        public CourseRepository(ApplicationContext Context) : base(Context)
        {
        }
    }
}
