namespace StudentInformationSystem.Utilities.Dto
{
    public class UpdatePasswordDto
    {
        public string NewPassword { get; set; }
        public string ConfrimPassword { get; set; }
        public string EmailAddress { get; set; }
        public string ResetToken { get; set; }
    }
}
