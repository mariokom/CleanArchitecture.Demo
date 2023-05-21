using MediatR;
using CAD.Core.Shared.Models;
using CAD.Domain.Entities;

namespace CAD.Core.Shared.Queries
{
    public class GetAcademicPeriodQuery : IRequest<AcademicPeriodModel>
    {
        public string AcademicPeriod { get; set; } = string.Empty;
    }
}
