using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Domain.Entities;
using System.Reflection;

namespace CAD.Core.ModelMapping.Mappers
{
    public class EmployeeMapper : IMapper<Employee, EmployeeModel>
    {
        public Employee ToEntity(EmployeeModel model)
        {
            return new Employee
            {
                Id = model.Id,
                Email = model.Email,
                EmployeeType = (Domain.Entities.EmployeeType)model.EmployeeType,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title
            };
        }

        public EmployeeModel ToModel(Employee entity)
        {
            return new EmployeeModel
            {
                Id = entity.Id,
                Email = entity.Email,
                EmployeeType = (Shared.Models.EmployeeType)entity.EmployeeType,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Title = entity.Title
            };
        }
    }
}
