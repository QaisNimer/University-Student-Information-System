using StudentInformationSystem.Infrastructure.Entities;

namespace StudentInformationSystem.Utilities.Dto
{
    public class CousreViewListDto
    {
        public CousreViewListDto()
        {
            courses= new List<Course>();
            courseRequest = new CourseRequest();
        }
        public List<Course> courses { get; set; }   
        public CourseRequest courseRequest { get; set; }

    }
    public class CourseRequest
    {
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public string CourseCode { get; set; }
    }
}
