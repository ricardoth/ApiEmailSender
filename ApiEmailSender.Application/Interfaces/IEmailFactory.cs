using ApiEmailSender.Application.Commands;
using ApiEmailSender.Infraestructure.Factory.EmailFactories;

namespace ApiEmailSender.Application.Interfaces
{
    public interface IEmailFactory
    {
        IEmail CreateEmail(SendEmailTicketCommand command);
    }
}
