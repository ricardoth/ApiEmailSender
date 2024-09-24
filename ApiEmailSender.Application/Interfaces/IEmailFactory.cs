namespace ApiEmailSender.Application.Interfaces
{
    public interface IEmailFactory
    {
        IEmail CreateEmail(SendEmailTicketCommand command);
        IEmail CreateEmail(ResetPasswordEmailCommand command);
    }
}
