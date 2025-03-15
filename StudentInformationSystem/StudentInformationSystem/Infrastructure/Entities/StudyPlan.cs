using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("StudyPlan")]
    public class StudyPlan
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string StudyPlanName { get; set; }
    }
}
