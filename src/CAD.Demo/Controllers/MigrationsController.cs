using MediatR;
using Microsoft.AspNetCore.Mvc;
using CAD.Core.Shared.Commands;

namespace CAD.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MigrationsController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedDatabse()
        {
            await _mediator.Send(new SeedDataCommand());
            return Ok();
        }
    }
}
