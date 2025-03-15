namespace StudentInformationSystem.BussinessLogic.ISevices
{
    public interface IEmailService
    {
        string GetEmailTemplate(string TemplateName, out string imageUrl);
        Task SendEmailAsync(string to, string subject, string body, long UserId, string imageUrl);
    }
}
