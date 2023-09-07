using MediatR;
using Microsoft.AspNetCore.Mvc;
using CAD.Core.Shared.Models;
using CAD.Core.Shared.Queries;

namespace CAD.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<List<CompanyModel>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            return await _mediator.Send(new GetCompaniesQuery
            {
                PaginationParams = paginationParams,
            });
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<CompanyModel>> Get([FromRoute] Guid companyId)
        {
            CompanyModel? company = await _mediator.Send(new GetCompanyQuery
            {
                CompanyId = companyId
            });

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        [HttpPost("")]
        public async Task<Guid> Add([FromBody] CompanyModel department)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid companyId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{companyId}")]
        public async Task<IActionResult> Update([FromRoute] Guid companyId, [FromBody] CompanyModel department)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{companyId}/departments")]
        public async Task<ActionResult> GetCompanyDepartments([FromRoute] Guid companyId)
        {
            return Ok();
        }

        [HttpPost("{companyId}/departments/{departmentId}")]
        public async Task<IActionResult> AddCompanyDepartments([FromRoute] Guid companyId, [FromRoute] Guid departmentId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{companyId}/departments/{departmentId}")]
        public async Task<IActionResult> RemoveCompanytDepartment([FromRoute] Guid companyId, [FromRoute] Guid departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
