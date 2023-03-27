using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unic.Core.Shared.Models;
using Unic.Core.Shared.Queries;
using Unic.Demo.Utils;

namespace Unic.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UniversityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("students")]
        [AuthorizeUser]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(
                await _mediator.Send(new GetStudentsQuery { })
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="academicPeriod">Use 'Fall 2023' (given that you've seeded the DB)</param>
        /// <returns></returns>
        [HttpGet("courses")]
        [AuthorizeUser]
        public async Task<IActionResult> GetCourses([FromQuery] string academicPeriod)
        {
            return Ok(
                await _mediator.Send(
                    new GetAcademicPeriodQuery { AcademicPeriod = academicPeriod }
                )
            );
        }

        [HttpGet("courses/all")]
        [AuthorizeUser]
        public async Task<IActionResult> GetAllCourses([FromQuery] PaginationParams paginationParams)
        {
            return Ok(
                await _mediator.Send(
                    new GetAllCoursesQuery { PaginationParams = paginationParams } 
                )
            );
        }

    }
}
