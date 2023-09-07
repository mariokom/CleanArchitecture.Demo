using CAD.Core.Shared.Models;
using CAD.Domain.Entities;

namespace CAD.Core.Shared.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<List<Company>> GetAll(PaginationParams paginationParams, CancellationToken cancellationToken = default);
        public Task<Company?> Get(Guid companyId, bool includeDepartments, CancellationToken cancellationToken = default);
        public Task<Company> Add(Company company, CancellationToken cancellationToken = default);
        public Task<int> Delete(Guid companyId, CancellationToken cancellationToken = default);
        public Task<Company> Update(Company company, CancellationToken cancellationToken = default);
        public Task<bool> AddDepartment(Company company, Department department, CancellationToken cancellationToken = default);
        public Task<bool> RemoveDepartment(Company company, Department department, CancellationToken cancellationToken = default);
    }
}
