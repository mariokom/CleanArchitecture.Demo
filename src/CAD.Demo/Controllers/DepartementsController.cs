using CAD.Core.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CAD.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public Task<List<DepartmentModel>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{departmentId}")]
        public Task<DepartmentModel> Get([FromQuery] Guid departmentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public Task<Guid> Add([FromBody] DepartmentModel employee)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{departmentId}")]
        public Task<IActionResult> Delete([FromQuery] Guid departmentId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{departmentId}")]
        public Task<IActionResult> Update([FromQuery] Guid departmentId, [FromBody] DepartmentModel employee)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{departmentId}/employees")]
        public Task<IActionResult> GetDepartmentEmployees([FromQuery] Guid departmentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{departmentId}/employees/{employeeId}")]
        public Task<IActionResult> AddDepartmentEmployees([FromQuery] Guid departmentId, [FromQuery] Guid employeeId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{departmentId}/employees/{employeeId}")]
        public Task<IActionResult> RemoveDepartmentEmployee([FromQuery] Guid departmentId, [FromQuery] Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
