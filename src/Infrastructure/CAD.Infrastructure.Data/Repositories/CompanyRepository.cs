using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAD.Infrastructure.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyDbContext _dbContext;

        public CompanyRepository(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> Add(Company company, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<Company>().Add(company);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return company;
        }

        public async Task<bool> AddDepartment(Company company, Department department, CancellationToken cancellationToken = default)
        {
            company.Departments ??= new List<Department>();

            company.Departments.Add(department);
            int affectedRows = await _dbContext.SaveChangesAsync(cancellationToken);

            return affectedRows > 0;
        }

        public async Task<int> Delete(Guid companyId, CancellationToken cancellationToken = default)
        {
            Company company = new Company { Id = companyId };

            var companyEntry = _dbContext.Entry(company);
            companyEntry.State = EntityState.Deleted;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Company?> Get(Guid companyId, bool includeDepartments, CancellationToken cancellationToken = default)
        {
            IQueryable<Company> companyQueryable = _dbContext.Set<Company>().AsQueryable();
            
            if (includeDepartments)
            {
                companyQueryable = companyQueryable.Include(c => c.Departments);
            }

            return await companyQueryable
                .FirstOrDefaultAsync(c => c.Id == companyId, cancellationToken);
        }

        public async Task<List<Company>> GetAll(PaginationParams paginationParams, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Company>().AsQueryable()
                .Include(cs => cs.Departments)
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> RemoveDepartment(Company company, Department department, CancellationToken cancellationToken = default)
        {
            company.Departments.Remove(department);
            return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Company> Update(Company company, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(company);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return company;
        }
    }
}
