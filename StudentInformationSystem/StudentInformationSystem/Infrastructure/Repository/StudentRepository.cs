using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudent
    {
        public StudentRepository(ApplicationContext Context) : base(Context)
        {
        }
    }
}
