using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Utilities.Dto
{
    public record RegisterCourseDto
    {
        public long CourseId { get; set; }
        public long StudentId { get; set; }

        [Required(ErrorMessage = "Course Characters are required")]
        public string CourseCharacters { get; set; }

        [Required(ErrorMessage = "Course Number is required")]
        public string CourseNumber { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Section is required")]
        public string Section { get; set; }

        [Required(ErrorMessage = "Semester is required")]
        public int SemesterId { get; set; }
    }
    public class AddCourseDto
    {
        public AddCourseDto()
        {
            RegisterCourse= new RegisterCourseDto();
            CourseList = new List<CourseListDto>();
        }
        public RegisterCourseDto RegisterCourse { get; set; }
        public List<CourseListDto> CourseList { get; set; }

    }
    public class CourseListDto
    {
        public long Id { get; set; }
        public int Credit { get; set; }
        public string CourseCharacters { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string Section { get; set; }
    }
}
