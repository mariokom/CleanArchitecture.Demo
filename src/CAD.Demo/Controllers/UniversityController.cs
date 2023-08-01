using MediatR;
using Microsoft.AspNetCore.Mvc;
using CAD.Core.Shared.Models;
using CAD.Core.Shared.Queries;
using CAD.Demo.Utils;
using System.Drawing.Text;

namespace CAD.Demo.Controllers
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

        public void Feature11_1()
        {

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


        //my feature comment
        //featureD1

        public void Feature11_2()
        {

        }
    }
}
