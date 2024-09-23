using ApiEmailSender.Application.Interfaces;
using ApiEmailSender.Infraestructure.Factory.EmailFactories;
using MediatR;

namespace ApiEmailSender.Application.Commands
{
    public class SendEmailTicketCommandHandler : IRequestHandler<SendEmailTicketCommand, bool>
    {
        private readonly IEmailFactory _emailFactory;

        public SendEmailTicketCommandHandler(IEmailFactory emailFactory)
        {
            _emailFactory = emailFactory;                
        }

        public async Task<bool> Handle(SendEmailTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IEmail emailService = _emailFactory.CreateEmail(request);

                var emailMessage = ((BaseEmail)emailService).CreateEmailMessage();
                await emailService.Send(emailMessage);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
