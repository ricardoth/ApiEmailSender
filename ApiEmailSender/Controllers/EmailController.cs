using ApiEmailSender.Application.Commands;
using ApiEmailSender.Domain.DTOs;
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

        [HttpPost("generateTicket")]
        public async Task<IActionResult> Post([FromBody] EmailTicketDto emailTicketDto)
        {
            var query = await _mediator.Send(new SendEmailTicketCommand(emailTicketDto));
            return Ok(query);
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> Post([FromBody] ResetPasswordEmailDto resetPasswordEmailDto)
        {
            var query = await _mediator.Send(new ResetPasswordEmailCommand(resetPasswordEmailDto));
            return Ok(query);
        }
    }
}
