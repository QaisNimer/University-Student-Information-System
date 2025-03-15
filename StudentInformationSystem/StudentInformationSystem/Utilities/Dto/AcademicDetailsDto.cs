using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Utilities.Dto
{
    public record CourseAcademicDetailsDto
    {
        public string Year { get; set; }
        public long Semester { get; set; }
        public string CourseCharacters { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public int NumberOfHours { get; set; }
        public int Marks { get; set; }
        public string MarksStatus { get; set; }
    }

    public record SummaryAcademicDetailDto 
    {
        public double CumulativeGPA { get; set; }
        public int NumberOfSemesterHours { get; set; }
        public int TotalHoursStuiedByStudent { get; set; }
        public double SemesterGPA { get; set; }
        public long Semester { get; set; }
        public string Year { get; set; }
    }

    public class AcademicDetailsDto
    {
        public int TotalCumulativeMarks { get; set; }
        public int TotalCumulativeHours { get; set; }
        public int CumulativeAverage { get; set; }
        public int TotalNumberOfHoursPassedByTheStudent { get; set; }
        public List<CourseAcademicDetailsDto> CourseAcademicDetailsDto { get; set; }
        public List<SummaryAcademicDetailDto> SummaryAcademicDetailDto { get; set; }

        public AcademicDetailsDto()
        {
            CourseAcademicDetailsDto = new List<CourseAcademicDetailsDto>();
            SummaryAcademicDetailDto = new List<SummaryAcademicDetailDto>();
        }
    }
}
