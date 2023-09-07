using Microsoft.EntityFrameworkCore;
using CAD.Domain.Entities;
using CAD.Infrastructure.Data.EntityConfigurations;
using System.Diagnostics.Metrics;

namespace CAD.Infrastructure.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            Company odyssey = new Company { Id = Guid.NewGuid(), Name = "Odyssey" };
            Company microsoft = new Company { Id = Guid.NewGuid(), Name = "Microsoft" };

            Department engineeringOdyssey = new Department { Id = Guid.NewGuid(), Name = "Engineering", CompanyId = odyssey.Id };
            Department salesOdyssey = new Department { Id = Guid.NewGuid(), Name = "Sales", CompanyId = odyssey.Id };
            Department engineeringMicrosoft = new Department { Id = Guid.NewGuid(), Name = "Engineering", CompanyId = microsoft.Id };
            Department salesMicrosoft = new Department { Id = Guid.NewGuid(), Name = "Sales", CompanyId = microsoft.Id };
            Department marketingMicrosoft = new Department { Id = Guid.NewGuid(), Name = "Marketing", CompanyId = microsoft.Id };

            Employee e0 = new Employee { Id = Guid.NewGuid(), FirstName = "First0", LastName = "Last0", DepartmentId = engineeringOdyssey.Id, Email = "e0@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e1 = new Employee { Id = Guid.NewGuid(), FirstName = "First1", LastName = "Last1", DepartmentId = engineeringOdyssey.Id, Email = "e1@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e2 = new Employee { Id = Guid.NewGuid(), FirstName = "First2", LastName = "Last2", DepartmentId = salesOdyssey.Id, Email = "e2@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e3 = new Employee { Id = Guid.NewGuid(), FirstName = "First3", LastName = "Last3", DepartmentId = engineeringMicrosoft.Id, Email = "e3@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e4 = new Employee { Id = Guid.NewGuid(), FirstName = "First4", LastName = "Last4", DepartmentId = engineeringMicrosoft.Id, Email = "e4@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e5 = new Employee { Id = Guid.NewGuid(), FirstName = "First5", LastName = "Last5", DepartmentId = engineeringMicrosoft.Id, Email = "e5@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e6 = new Employee { Id = Guid.NewGuid(), FirstName = "First6", LastName = "Last6", DepartmentId = engineeringMicrosoft.Id, Email = "e6@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e7 = new Employee { Id = Guid.NewGuid(), FirstName = "First7", LastName = "Last7", DepartmentId = salesMicrosoft.Id, Email = "e7@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e8 = new Employee { Id = Guid.NewGuid(), FirstName = "First8", LastName = "Last8", DepartmentId = marketingMicrosoft.Id, Email = "e8@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };
            Employee e9 = new Employee { Id = Guid.NewGuid(), FirstName = "First9", LastName = "Last9", DepartmentId = marketingMicrosoft.Id, Email = "e9@company.com", EmployeeType = EmployeeType.Employee, Title = "junior" };

            modelBuilder.Entity<Company>().HasData(
                new List<Company>() { odyssey, microsoft }
            );

            modelBuilder.Entity<Department>().HasData(
                new List<Department>() { engineeringOdyssey, salesOdyssey, engineeringMicrosoft, salesMicrosoft, marketingMicrosoft }
            );

            modelBuilder.Entity<Employee>().HasData(
                new List<Employee>() { e0, e1, e2, e3, e4, e5, e6, e7, e8, e9 }
            );
        }
    }
}
