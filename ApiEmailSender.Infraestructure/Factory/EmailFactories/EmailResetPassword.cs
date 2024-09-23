
using ApiEmailSender.Domain.Entities;
using ApiEmailSender.Domain.ValueObjects;
using MimeKit;

namespace ApiEmailSender.Infraestructure.Factory.EmailFactories
{
    public class EmailResetPassword : BaseEmail
    {
        public EmailResetPassword(EmailConfig emailConfig) : base(emailConfig) { }

        public async override Task Send()
        {
            var email = CreateEmailMessage();
        }
        
    }
}
