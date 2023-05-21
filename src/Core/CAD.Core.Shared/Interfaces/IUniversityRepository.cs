using CAD.Core.Shared.Models;
using CAD.Domain.Entities;

namespace CAD.Core.Shared.Interfaces
{
    public interface IUniversityRepository
    {
        public Task<List<Student>> GetStudentsForLecturer(int userId);
        public Task<List<Student>> GetStudentsForStudent(int userId);
        public Task AddAcademicPeriodAsync(AcademicPeriod academicPeriod, CancellationToken cancellationToken = default);
        public Task<AcademicPeriod?> GetAcademicPeriodAsync(string academicPeriodName, CancellationToken cancellationToken = default);
        public Task<List<CourseSection>> GetAllCourses(PaginationParams paginationParams, CancellationToken cancellationToken = default);
        public Task<AcademicPeriod?> GetFirstAcademicPeriod(CancellationToken cancellationToken = default);
    }
}
