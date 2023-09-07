using CAD.Core.Shared.Models;
using CAD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Core.Shared.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<List<Company>> GetAll(PaginationParams paginationParams, CancellationToken cancellationToken = default);
        public Task<Department> Get(int departemntId, CancellationToken cancellationToken = default);
        public Task<Department> Add(Department department, CancellationToken cancellationToken = default);
        public Task<int> Delete(Guid departemntId, CancellationToken cancellationToken = default);
        public Task<Department> Update(Guid departemntId, CancellationToken cancellationToken = default);
    }
}
