using ApiEmailSender.Application.Commands;
using ApiEmailSender.Application.Interfaces;
using ApiEmailSender.Domain.ValueObjects;
using ApiEmailSender.Infraestructure.Factory.EmailFactories;

namespace ApiEmailSender.Application.Factories
{
    public class EmailFactory : IEmailFactory
    {
        private readonly EmailConfig _emailConfig;

        public EmailFactory(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;       
        }

        public IEmail CreateEmail(SendEmailTicketCommand command)
        {
            return new EmailWithTicket(_emailConfig)
            {
                To = command.EmailTicket.To,
                Subject = command.EmailTicket.Subject,
                Body = command.EmailTicket.Body,
                IdTicket = command.EmailTicket.IdTicket,
                PdfBase64 = command.EmailTicket.Base64
            };
        }
    }
}
