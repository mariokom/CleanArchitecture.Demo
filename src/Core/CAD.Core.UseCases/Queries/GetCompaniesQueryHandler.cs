using MediatR;
using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Core.Shared.Queries;
using CAD.Core.TokenAuthorization;
using CAD.Domain.Entities;
using CAD.Core.ModelMapping.Mappers;

namespace CAD.Core.UseCases.Queries
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, List<CompanyModel>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyMapper _companyMapper;

        public GetCompaniesQueryHandler(ICompanyRepository companyRepository, CompanyMapper companyMapper)
        {
            _companyRepository = companyRepository;
            _companyMapper = companyMapper;
        }

        // TODO include departments, think of queryable
        public async Task<List<CompanyModel>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            List<Company> companies = await _companyRepository.GetAll(
                request.PaginationParams, cancellationToken
            );

            List<CompanyModel> courseModels = companies.Select(c => 
                _companyMapper.ToModel(c)
            ).ToList();

            return await Task.FromResult(courseModels);
        }
    }
}
