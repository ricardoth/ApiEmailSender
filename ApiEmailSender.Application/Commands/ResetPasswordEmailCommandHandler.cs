namespace ApiEmailSender.Application.Commands
{
    public class ResetPasswordEmailCommandHandler : IRequestHandler<ResetPasswordEmailCommand, bool>
    {
        private readonly IEmailFactory _emailFactory;

        public ResetPasswordEmailCommandHandler(IEmailFactory emailFactory)
        {
            _emailFactory = emailFactory;       
        }

        public async Task<bool> Handle(ResetPasswordEmailCommand request, CancellationToken cancellationToken)
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
