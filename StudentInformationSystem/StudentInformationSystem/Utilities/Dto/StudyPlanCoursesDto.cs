using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Utilities.Dto
{
    public class StudyPlanCoursesListDto
    {
        public StudyPlanCoursesListDto()
        {
            CompulsoryUniversity = new List<StudyPlanCoursesDto>();
            CompulsorySection = new List<StudyPlanCoursesDto>();
            OptionalUniversity = new List<StudyPlanCoursesDto>();
            CompulsoryCollege = new List<StudyPlanCoursesDto>();
            ElectiveDepartment = new List<StudyPlanCoursesDto>();
        }
        public List<StudyPlanCoursesDto> CompulsoryUniversity { get; set; }
        public List<StudyPlanCoursesDto> CompulsorySection { get; set; }
        public List<StudyPlanCoursesDto> OptionalUniversity { get; set; }
        public List<StudyPlanCoursesDto> CompulsoryCollege { get; set; }
        public List<StudyPlanCoursesDto> ElectiveDepartment { get; set; }
        public int CompulsoryUniversityTotalCredits { get; set; }
        public int CompulsorySectionTotalCredits { get; set; }
        public int OptionalUniversityTotalCredits { get; set; }
        public int CompulsoryCollegeTotalCredits { get; set; }
        public int ElectiveDepartmentTotalCredits { get; set; }
    }

    public record StudyPlanCoursesDto
    {
        public long Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string HeStudyIt { get; set; } 
    }
}
