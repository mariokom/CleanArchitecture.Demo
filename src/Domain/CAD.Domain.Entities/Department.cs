using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
