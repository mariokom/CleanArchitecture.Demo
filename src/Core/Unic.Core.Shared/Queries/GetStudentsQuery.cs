using MediatR;
using Unic.Core.Shared.Models;

namespace Unic.Core.Shared.Queries
{
    public class GetStudentsQuery : IRequest<List<StudentModel>>
    {
    }
}
