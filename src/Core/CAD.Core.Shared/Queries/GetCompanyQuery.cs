using MediatR;
using CAD.Core.Shared.Models;

namespace CAD.Core.Shared.Queries
{
    public class GetCompanyQuery : IRequest<CompanyModel?>
    {
        public Guid CompanyId { get; set; }
    }
}
