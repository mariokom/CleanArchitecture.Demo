namespace CAD.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FounderName { get; set; } = string.Empty;

        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
