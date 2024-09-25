using ApiEmailSender.Application.Validators;
using FluentValidation;

namespace ApiEmailSender.Application.Commands
{
    public class SendEmailTicketCommandHandler : IRequestHandler<SendEmailTicketCommand, BaseResponse>
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IValidator<EmailTicketDto> _validator;

        public SendEmailTicketCommandHandler(IEmailFactory emailFactory, IValidator<EmailTicketDto> validator)
        {
            _emailFactory = emailFactory;
            _validator = validator;
        }

        public async Task<BaseResponse> Handle(SendEmailTicketCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request.EmailTicket);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errors);
            }

            try
            {
                IEmail email = _emailFactory.CreateEmail(request);
                await email.Send();

                var baseResponse = new BaseResponse()
                {
                    Message = $"Se ha enviado correctamente el email a {request.EmailTicket.To}"
                };
                return baseResponse;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}