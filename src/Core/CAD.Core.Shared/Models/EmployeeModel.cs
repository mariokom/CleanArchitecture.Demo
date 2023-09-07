using CAD.Domain.Entities;

namespace CAD.Core.Shared.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EmployeeType EmployeeType { get; set; }

        public EmployeeModel Manager { get; set; }
        public List<EmployeeModel> Employees { get; set; }
        public DepartmentModel Department { get; set; }
    }
}
