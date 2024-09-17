using ApiEmailSender.Application.Email.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = await _mediator.Send(new EmailSenderQuery());
            return Ok(query);
        }
    }
}
