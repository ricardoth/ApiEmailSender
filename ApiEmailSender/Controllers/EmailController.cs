namespace ApiEmailSender.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;   
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
            var query = await _mediator.Send(new ResetPasswordEmailCommand(resetPasswordEmailDto));
            return query;
        }
    }
}
