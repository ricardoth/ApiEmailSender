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
            return new EmailTicketBase64(_emailConfig)
            {
                To = command.EmailTicket.To,
                Subject = command.EmailTicket.Subject,
                PdfBase64 = command.EmailTicket.Base64,
                IdTicket = command.EmailTicket.IdTicket,
                Nombres = command.EmailTicket.Nombres,
                ApellidoPaterno = command.EmailTicket.ApellidoPaterno,
                ApellidoMaterno = command.EmailTicket.ApellidoMaterno,
                NombreEvento = command.EmailTicket.NombreEvento,
                NombreLugar = command.EmailTicket.NombreLugar,
                NombreSector = command.EmailTicket.NombreSector,
                MontoTotal = command.EmailTicket.MontoTotal 
            };
        }

        public IEmail CreateEmail(ResetPasswordEmailCommand command)
        {
            return new EmailResetPassword(_emailConfig)
            {
                To = command.ResetPasswordEmail.To,
                Subject = command.ResetPasswordEmail.Subject,
                UrlRetorno = command.ResetPasswordEmail.UrlRetorno
            };
        }
    }
}