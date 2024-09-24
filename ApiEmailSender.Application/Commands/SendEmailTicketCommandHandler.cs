﻿namespace ApiEmailSender.Application.Commands
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
                IEmail email = _emailFactory.CreateEmail(request);
                await email.Send();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}