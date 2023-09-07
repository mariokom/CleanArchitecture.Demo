using CAD.Core.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CAD.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public Task<List<EmployeeModel>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{employeeId}")]
        public Task<EmployeeModel> Get([FromQuery] Guid employeeId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public Task<Guid> Add([FromBody] EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{employeeId}")]
        public Task<IActionResult> Delete([FromQuery] Guid employeeId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{employeeId}")]
        public Task<IActionResult> Update([FromQuery] Guid employeeId, [FromBody] EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

    }
}
