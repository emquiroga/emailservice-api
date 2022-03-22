using EmailService.Core.Common.Email.Model;
using EmailService.Core.Interfaces;
using Mailjet.Client;

namespace EmailService.Core.Common.Email.EmailSender
{
    public abstract class EmailSender : IEmailSender
    {
        public static MailjetClient CreateMailJetClient()
        {
            return new MailjetClient("9052c370b8f06b230ed27c893a810aaa", "6b4ad338922e9626154a7b3a9e37f6d1");
        }
        protected abstract Task Send(EmailModel email);
     
        public async Task SendEmail(EmailModel emailModel)
        {
            await Send(emailModel);
        }

        public async Task SendEmail(string address, string subject, string body, List<EmailAttachment>? emailAttachment = null)
        {
            await Send(new EmailModel
            {
                Attachments = emailAttachment!,
                Body = body,
                EmailAddress = address,
                Subject = subject,
            });
        }
    }
}
