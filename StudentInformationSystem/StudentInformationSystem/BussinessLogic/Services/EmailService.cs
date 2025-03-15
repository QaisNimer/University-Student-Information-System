using StudentInformationSystem.BussinessLogic.ISevices;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using StudentInformationSystem.Utilities.Dto;
using Microsoft.VisualBasic;
using StudentInformationSystem.Utilities.Constrant;
using System.Drawing;

namespace StudentInformationSystem.BussinessLogic.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettingsDto _smtpSettings;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _webHostEnvironment;
        
        public EmailService(
            IConfiguration configuration, 
            Microsoft.AspNetCore.Hosting.IHostingEnvironment webHostEnvironment
            
            )
        {
            _smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpSettingsDto>();
            _webHostEnvironment = webHostEnvironment;
            
        }

        public string GetEmailTemplate(string TemplateName, out string imageUrl)
        {
            imageUrl = string.Empty;
            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, Constant.EmailTemplates, TemplateName);
            string templateContent = File.ReadAllText(templatePath);

            // Replace [IMAGE_URL] placeholder with the actual URL for image
            string webRootPath = _webHostEnvironment.WebRootPath.Replace("\\", "/");
            imageUrl = $"{webRootPath}/app-assets/images/ico/favicon.ico";

            return templateContent;
        }


        public async Task SendEmailAsync(string to, string subject, string body, long UserId, string imageUrl)
        {
            
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_smtpSettings.UserName, "Student Information Portal");
                message.To.Add(to);
                message.Body = body;
                message.Subject = subject;
                message.IsBodyHtml = true;
                NetworkCredential smtpNC = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);

                // Attach the image
                var inlineLogo = new LinkedResource(imageUrl, "image/ico");
                inlineLogo.ContentId = "Projectlogo";

                // Add the linked resource to the email
                var avHtml = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
                avHtml.LinkedResources.Add(inlineLogo);
                message.AlternateViews.Add(avHtml);

                SmtpClient client = new SmtpClient(_smtpSettings.Host);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                client.Host = _smtpSettings.Host;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Port = _smtpSettings.Port;
                client.EnableSsl = _smtpSettings.EnableSsl;
                client.TargetName = _smtpSettings.Host;

                await client.SendMailAsync(message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
            
        }

    }
}
