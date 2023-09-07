using MediatR;
using CAD.Core.Shared.Models;

namespace CAD.Core.Shared.Queries
{
    public class GetCompaniesQuery : IRequest<List<CompanyModel>>
    {
        public PaginationParams PaginationParams { get; set; } = new PaginationParams();
        public bool IncludeDepartments { get; set; }
    }
}
