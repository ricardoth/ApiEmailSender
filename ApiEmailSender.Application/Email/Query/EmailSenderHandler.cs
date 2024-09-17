using ApiEmailSender.Domain;
using AutoMapper;
using MediatR;

namespace ApiEmailSender.Application.Email.Query
{
    public class EmailSenderHandler : IRequestHandler<EmailSenderQuery, EmailSenderResult>
    {
        private readonly IMapper _mapper;

        public EmailSenderHandler(IMapper mapper)
        {
            _mapper = mapper;        
        }

        public async Task<EmailSenderResult> Handle(EmailSenderQuery request, CancellationToken cancellationToken)
        {
            EmailSend send = new EmailSend();
            var emailMapper = _mapper.Map<EmailSenderResult>(send);
            return emailMapper;
        }
    }
}
