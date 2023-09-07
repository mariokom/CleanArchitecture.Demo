namespace CAD.Core.Shared.Models
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
        public CompanyModel Company { get; set; }
    }
}
