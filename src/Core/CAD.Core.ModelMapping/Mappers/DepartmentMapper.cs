using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Domain.Entities;
using System.Drawing;
using System.Reflection;

namespace CAD.Core.ModelMapping.Mappers
{
    public class DepartmentMapper : IMapper<Department, DepartmentModel>
    {
        private readonly EmployeeMapper _employeeMapper;

        public DepartmentMapper(EmployeeMapper employeeMapper)
        {
            _employeeMapper = employeeMapper;
        }

        public Department ToEntity(DepartmentModel model)
        {
            return new Department { 
                Id = model.Id,
                Name = model.Name,
                Employees = MapToEmployees(model.Employees ?? new List<EmployeeModel>())
            };
        }

        private List<Employee> MapToEmployees(List<EmployeeModel> employees)
        {
            return employees.Select(
                e => _employeeMapper.ToEntity(e)
            ).ToList();
        }

        public DepartmentModel ToModel(Department entity)
        {
            return new DepartmentModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Employees = MapToEmployeeModels(entity.Employees ?? new List<Employee>())
            };
        }

        private List<EmployeeModel> MapToEmployeeModels(ICollection<Employee> employees)
        {
            return employees.Select(
                e => _employeeMapper.ToModel(e)
            ).ToList();
        }
    }
}
