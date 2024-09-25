using ApiEmailSender.Domain.Exceptions;
using MailKit.Net.Smtp;
using Microsoft.ApplicationInsights;

namespace ApiEmailSender.Infraestructure.Factory.EmailFactories
{
    public abstract class BaseEmail : IEmail
    {
        protected readonly EmailConfig _emailConfig;
        public string To { get; set; }
        public string Subject { get; set; }

        public BaseEmail(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;   
        }

        public MimeMessage CreateEmailMessage()
        {
            var email = new MimeMessage();
            email.Subject = Subject;
            email.From.Add(new MailboxAddress("Resonance Pass", _emailConfig.From));
            email.To.Add(new MailboxAddress("Destinatario", To));
            return email;
        }

        protected async Task SendEmail(MimeMessage email)
        {
            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_emailConfig.Host, Convert.ToInt32(_emailConfig.Port), MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Ha ocurrido un error al enviar el correo {ex.Message}");
            }
            finally
            {
                smtp.Disconnect(true);
            }

        }

        public abstract Task Send();
    }
}
