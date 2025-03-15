using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("RegisteredCourses")]
    public class RegisteredCourses
    {
        [Key]
        public long Id { get; set; }
        public long CourseId { get; set; }
        public long StudentId { get; set; }
        public long SemesterId { get; set; }
        public DateTime AddedOn { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(SemesterId))]
        public Semester Semester { get; set; }
    }
}
