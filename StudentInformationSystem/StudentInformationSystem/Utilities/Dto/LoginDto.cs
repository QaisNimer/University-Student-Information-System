using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Utilities.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "College ID is required.")]
        public string CollegeId { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }   
    }
}
