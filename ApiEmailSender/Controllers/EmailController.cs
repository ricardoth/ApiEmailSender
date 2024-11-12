namespace ApiEmailSender.WebApi.Controllers
{
    [Authorize]
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

        [HttpPost("resetPassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<BaseResponse> Post([FromBody] ResetPasswordEmailDto resetPasswordEmailDto)
        {
            _telemetryClient.TrackTrace("[INFO] POST api/email/resetPassword - Invocado");
            var query = await _mediator.Send(new ResetPasswordEmailCommand(resetPasswordEmailDto));
            _telemetryClient.TrackTrace("[INFO] POST api/email/resetPassword - Request Exitoso");
            return query;
        }
    }
}
