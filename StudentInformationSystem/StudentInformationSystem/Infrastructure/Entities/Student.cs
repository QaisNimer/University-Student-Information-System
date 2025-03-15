using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public long Id { get; set; }
        public long DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Departments { get; set; }
        [Required]
        [StringLength(50)]
        public string ArabicName { get; set; }
        [Required]
        [StringLength(50)]
        public string EnglishName { get; set; }
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string CollegeID { get; set; }
        [Required]
        public string CollegeName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
        [Required]
        public string BirthDate { get; set; }
        
        public string? Specilization { get; set; }

        public string? SUbSpecilty { get; set; }
       
        public string? AcademicStatus { get; set; }
        public DateTime? ForgetPasswordRequestOn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? CumulativeAverage { get; set; }
        public string GaduateStatus { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
