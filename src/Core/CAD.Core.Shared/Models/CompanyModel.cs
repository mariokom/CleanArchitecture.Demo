namespace CAD.Core.Shared.Models
{
    public class CompanyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<DepartmentModel> Departments { get; set; } = new List<DepartmentModel>();
    }
}
