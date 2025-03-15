using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class SemesterRepository : GenericRepository<Semester>, ISemester
    {
        public SemesterRepository(ApplicationContext Context) : base(Context)
        {

        }
    }
}
