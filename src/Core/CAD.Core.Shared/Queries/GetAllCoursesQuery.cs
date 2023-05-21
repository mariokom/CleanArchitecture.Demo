using MediatR;
using CAD.Core.Shared.Models;

namespace CAD.Core.Shared.Queries
{
    public class GetAllCoursesQuery : IRequest<List<CourseModel>>
    {
        public PaginationParams PaginationParams { get; set; } = new PaginationParams();
    }
}
