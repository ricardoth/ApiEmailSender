namespace ApiEmailSender.Application.Commands
{
    public class ResetPasswordEmailCommandHandler : IRequestHandler<ResetPasswordEmailCommand, BaseResponse>
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IValidator<ResetPasswordEmailCommand> _validator;

        public ResetPasswordEmailCommandHandler(IEmailFactory emailFactory, IValidator<ResetPasswordEmailCommand> validator)
        {
            _emailFactory = emailFactory;       
            _validator = validator;
        }

        public async Task<BaseResponse> Handle(ResetPasswordEmailCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
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
                    StatusCode = 200,
                    Message = $"Se ha enviado correctamente el email a {request.ResetPasswordEmail.To}"
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
