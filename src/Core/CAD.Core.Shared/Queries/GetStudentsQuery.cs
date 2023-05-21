using MediatR;
using CAD.Core.Shared.Models;

namespace CAD.Core.Shared.Queries
{
    public class GetStudentsQuery : IRequest<List<StudentModel>>
    {
    }
}
