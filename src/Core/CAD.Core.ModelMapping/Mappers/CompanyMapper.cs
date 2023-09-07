using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Domain.Entities;

namespace CAD.Core.ModelMapping.Mappers
{
    public class CompanyMapper : IMapper<Company, CompanyModel>
    {
        private readonly DepartmentMapper _departmentMapper;

        public CompanyMapper(DepartmentMapper departmentMapper) 
        {
            _departmentMapper = departmentMapper;
        }

        public Company ToEntity(CompanyModel model)
        {
            return new Company
            {
                Id = model.Id,
                Name = model.Name,
                Departments = MapToDepartments(model.Departments ?? new List<DepartmentModel>())
            };
        }

        private List<Department> MapToDepartments(List<DepartmentModel> departments)
        {
            return departments.Select(
                d => _departmentMapper.ToEntity(d)
            ).ToList();
        }

        public CompanyModel ToModel(Company entity)
        {
            return new CompanyModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Departments = MapToDepartmentModels(entity.Departments ?? new List<Department>())
            };
        }

        private List<DepartmentModel> MapToDepartmentModels(ICollection<Department> departments)
        {
            return departments.Select(
                d => _departmentMapper.ToModel(d)
            ).ToList();
        }
    }
}
