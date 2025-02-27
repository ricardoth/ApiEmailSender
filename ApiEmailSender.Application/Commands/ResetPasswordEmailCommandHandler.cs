namespace ApiEmailSender.Application.Commands
{
    public class ResetPasswordEmailCommandHandler : IRequestHandler<ResetPasswordEmailCommand, BaseResponse>
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IValidator<ResetPasswordEmailDto> _validator;
        private readonly TelemetryClient _telemetryClient;

        public ResetPasswordEmailCommandHandler(IEmailFactory emailFactory, 
            IValidator<ResetPasswordEmailDto> validator,
            TelemetryClient telemetryClient)
        {
            _emailFactory = emailFactory;       
            _validator = validator;
            _telemetryClient = telemetryClient;
        }

        public async Task<BaseResponse> Handle(ResetPasswordEmailCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request.ResetPasswordEmail);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _telemetryClient.TrackException(new ValidationResultException(errors));
                throw new ValidationResultException(errors);
            }

            try
            {
                IEmail email = _emailFactory.CreateEmail(request);
                _telemetryClient.TrackTrace("[INFO] POST api/email/requestResetPassword - Generación de Email y Template.");
                await email.Send();

                _telemetryClient.TrackTrace($"[INFO] POST api/email/requestResetPassword - Correo Enviado a {request.ResetPasswordEmail.To}.");
                var baseResponse = new BaseResponse()
                {
                    Message = $"Se ha enviado correctamente el email a {request.ResetPasswordEmail.To}"
                };
                return baseResponse;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
