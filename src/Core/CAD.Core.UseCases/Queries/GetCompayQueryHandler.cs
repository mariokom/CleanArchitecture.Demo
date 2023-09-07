using MediatR;
using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Core.Shared.Queries;
using CAD.Core.TokenAuthorization;
using CAD.Domain.Entities;
using CAD.Core.ModelMapping.Mappers;

namespace CAD.Core.UseCases.Queries
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyModel?>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyMapper _companyMapper;

        public GetCompanyQueryHandler(ICompanyRepository companyRepository, CompanyMapper companyMapper)
        {
            _companyRepository = companyRepository;
            _companyMapper = companyMapper;
        }

        public async Task<CompanyModel?> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.Get(
                request.CompanyId, true, cancellationToken
            );

            if (company == default)
            {
                return null;
            }
            return _companyMapper.ToModel(company);
        }
    }
}
