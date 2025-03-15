using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public long StudyPlanId { get; set; }

        [Required]
        public string CourseName { get; set; }
        //[Required]
        public string? CourseCode { get; set; }    
        [Required]
        public string CourseNumber { get; set; }
        [Required]
        [MaxLength(1)]
        public int Credits { get; set; }
        [Required]
        public string Section { get; set; }
        public bool IsSaturday { get; set; }  
        public bool IsSunday { get; set; }  
        public bool IsMonday { get; set; }  
        public bool IsTuesday { get; set; }  
        public bool IsWednesday { get; set; }  
        public bool IsThursday { get; set; }  
        [Required]
        public string TreacherName { get; set; }
        [Required]
        public string TimeForm { get; set; }
        [Required]
        public string TimeTo { get; set; }
        [Required]
        public int  AvailableSeat { get; set; }
        [Required]
        public string HallNumber { get; set; }
        [Required]
        public string CourseNature { get; set; }
        public string? Note { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Departments { get; set; }

        [ForeignKey(nameof(StudyPlanId))]
        public StudyPlan StudyPlan { get; set; }
    }
}
