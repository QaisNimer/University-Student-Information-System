using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("Marks")]
    public class Marks
    {
        [Key]
        public long Id { get; set; }
        public long RegisteredCourseId { get; set; }
        public int FirstMarks { get; set; }
        public int SecondMarks { get; set; }
        public int FinalMarks { get; set; }
        public string MarksStatus { get; set; }

        [ForeignKey(nameof(RegisteredCourseId))]
        public RegisteredCourses RegisteredCourses { get; set; }
    }
}
