using MediatR;
using Unic.Core.Shared.Models;
using Unic.Domain.Entities;

namespace Unic.Core.Shared.Queries
{
    public class GetAcademicPeriodQuery : IRequest<AcademicPeriodModel>
    {
        public string AcademicPeriod { get; set; } = string.Empty;
    }
}
