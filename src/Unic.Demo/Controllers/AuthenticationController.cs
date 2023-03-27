using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unic.Core.Shared.Commands;

namespace Unic.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("token")]
        public async Task<IActionResult> Authenticate([FromHeader]string username, [FromHeader] string password)
        {
            string token = await _mediator.Send(new AuthenticateCommand(username, password));

            return Ok(token);
        }
    }
}
