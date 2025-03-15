using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using StudentInformationSystem.Utilities.Dto;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class RegisterCourseRepository : GenericRepository<RegisteredCourses>, IRegisterCourse
    {
        private readonly ApplicationContext _Context;

        public RegisterCourseRepository(ApplicationContext Context) : base(Context)
        {
            _Context = Context;
        }

        public Tuple<List<CourseListDto>, long, List<Course>> GetRegisteredCoursesByStudent(long StudentId) 
        {
            try
            {
                var latestSemesterId = _Context.RegisteredCourses
                    .Where(rc => rc.StudentId == StudentId)
                    .OrderByDescending(rc => rc.SemesterId)
                    .Select(rc => rc.SemesterId)
                    .FirstOrDefault();

                latestSemesterId = latestSemesterId is 0 ? 1 : latestSemesterId;

                var Result = (from rc in _Context.RegisteredCourses
                                   join c in _Context.Courses on rc.CourseId equals c.Id
                                   where rc.StudentId == StudentId && rc.SemesterId == latestSemesterId
                                   select new CourseListDto
                                   {
                                       Id = c.Id,
                                       Credit = c.Credits,
                                       CourseCharacters = c.CourseCode,
                                       CourseName = c.CourseName,
                                       CourseNumber = c.CourseNumber,
                                       Section = c.Section,
                                   }).ToList();

                long requiredCreditHours = latestSemesterId * 18;
                var courses = _Context.Courses.ToList();
                var selectedCourses = courses
                    .OrderBy(c => c.CourseNumber)
                    .TakeWhile((c, index) => courses.Take(index + 1).Sum(x => x.Credits) <= requiredCreditHours)
                    .ToList();

                return Tuple.Create(Result, latestSemesterId, selectedCourses);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
