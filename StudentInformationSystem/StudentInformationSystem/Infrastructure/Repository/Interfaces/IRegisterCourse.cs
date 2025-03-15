using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Utilities.Dto;

namespace StudentInformationSystem.Infrastructure.Repository.Interfaces
{
    public interface IRegisterCourse : IGenericRepository<RegisteredCourses>
    {
        Tuple<List<CourseListDto>, long, List<Course>> GetRegisteredCoursesByStudent(long StudentId);
    }
}
