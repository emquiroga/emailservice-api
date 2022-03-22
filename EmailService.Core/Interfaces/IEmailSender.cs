using EmailService.Core.Common.Email.Model;

namespace EmailService.Core.Interfaces
{
    public interface IEmailSender
    {
        //Email Sender Contract
        Task SendEmail(string address, string subject, string body, List<EmailAttachment>? emailAttachment = null);
        Task SendEmail(EmailModel email);
    }
}
