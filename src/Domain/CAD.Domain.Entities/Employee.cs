using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Email { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
