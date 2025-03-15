using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string Short { get; set; }
    }
}
