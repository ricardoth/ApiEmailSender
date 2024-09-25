namespace ApiEmailSender.Application.Commands
{
    public class SendEmailTicketCommandHandler : IRequestHandler<SendEmailTicketCommand, BaseResponse>
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IValidator<EmailTicketDto> _validator;
        private readonly TelemetryClient _telemetryClient;

        public SendEmailTicketCommandHandler(IEmailFactory emailFactory, IValidator<EmailTicketDto> validator, TelemetryClient telemetryClient)
        {
            _emailFactory = emailFactory;
            _validator = validator;
            _telemetryClient = telemetryClient;

        }

        public async Task<BaseResponse> Handle(SendEmailTicketCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request.EmailTicket);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _telemetryClient.TrackException(new ValidationResultException(errors));
                throw new ValidationResultException(errors);
            }

            try
            {
                IEmail email = _emailFactory.CreateEmail(request);
                _telemetryClient.TrackTrace("[INFO] POST api/email/generateTicket - Generación de Email y Template.");
                await email.Send();

                _telemetryClient.TrackTrace($"[INFO] POST api/email/generateTicket - Correo Enviado a {request.EmailTicket.To}.");
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