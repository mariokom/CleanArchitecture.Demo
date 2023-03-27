using MediatR;
using Unic.Core.Shared.Models;

namespace Unic.Core.Shared.Queries
{
    public class GetAllCoursesQuery : IRequest<List<CourseModel>>
    {
        public PaginationParams PaginationParams { get; set; } = new PaginationParams();
    }
}
