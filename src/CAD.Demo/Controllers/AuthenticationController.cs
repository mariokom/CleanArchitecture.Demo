using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAD.Core.Shared.Commands;

namespace CAD.Demo.Controllers
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

        public void Feature22(string enhancement1)
        {

        }

        public void Feature21(string enhancement1)
        {

        }
    }
}
