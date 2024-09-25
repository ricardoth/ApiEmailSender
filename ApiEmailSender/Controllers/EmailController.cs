using Microsoft.ApplicationInsights;

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

        [HttpPost("generateTicket")]
        public async Task<BaseResponse> Post([FromBody] EmailTicketDto emailTicketDto)
        {
            var query = await _mediator.Send(new SendEmailTicketCommand(emailTicketDto));
            return query;
        }

        [HttpPost("resetPassword")]
        public async Task<BaseResponse> Post([FromBody] ResetPasswordEmailDto resetPasswordEmailDto)
        {
            _telemetryClient.TrackEvent("[INFO] POST api/email/resetPassword - Invocado");
            _telemetryClient.TrackTrace("[INFO] POST api/email/resetPassword - Invocado");
            var query = await _mediator.Send(new ResetPasswordEmailCommand(resetPasswordEmailDto));
            _telemetryClient.TrackEvent("[INFO] POST api/email/resetPassword - Request Exitoso");
            return query;
        }
    }
}
