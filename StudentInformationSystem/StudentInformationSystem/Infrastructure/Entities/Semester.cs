using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("Semester")]
    public class Semester
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string SemesterName { get; set; }
    }
}
