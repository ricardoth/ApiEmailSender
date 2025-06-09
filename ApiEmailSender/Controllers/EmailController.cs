namespace ApiEmailSender.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TelemetryClient _telemetryClient;

        public EmailController(IMediator mediator, TelemetryClient telemetryClient)
        {
            _mediator = mediator;   
            _telemetryClient = telemetryClient;
        }

        [Authorize]
        [HttpPost("generateTicket")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<BaseResponse> Post([FromBody] EmailTicketDto emailTicketDto)
        {
            _telemetryClient.TrackTrace("[INFO] POST api/email/generateTicket - Invocado");
            var query = await _mediator.Send(new SendEmailTicketCommand(emailTicketDto));
            _telemetryClient.TrackTrace("[INFO] POST api/email/generateTicket - Request Exitoso");
            return query;
        }

        [HttpPost("requestResetPassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<BaseResponse> Post([FromBody] ResetPasswordEmailDto resetPasswordEmailDto)
        {
            _telemetryClient.TrackTrace("[INFO] POST api/email/requestResetPassword - Invocado");
            var query = await _mediator.Send(new ResetPasswordEmailCommand(resetPasswordEmailDto));
            _telemetryClient.TrackTrace("[INFO] POST api/email/requestResetPassword - Request Exitoso");
            return query;
        }
    }
}
