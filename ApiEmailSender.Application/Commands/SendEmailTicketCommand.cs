namespace ApiEmailSender.Application.Commands
{
    public class SendEmailTicketCommand : IRequest<BaseResponse>
    {
        public EmailTicketDto EmailTicket { get; set; }

        public SendEmailTicketCommand(EmailTicketDto emailTicketDto)
        {
            EmailTicket = emailTicketDto;    
        }
    }
}