using Microsoft.EntityFrameworkCore;
using System.Linq;
using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.Repositories
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly AppDbContext _dbContext;

        public UniversityRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task AddAcademicPeriodAsync(AcademicPeriod academicPeriod, CancellationToken cancellationToken = default)
        {
            _dbContext.AcademicPeriod.Add(academicPeriod);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<AcademicPeriod?> GetAcademicPeriodAsync(string academicPeriodName, CancellationToken cancellationToken = default)
        {
            return await _dbContext.AcademicPeriod
                .Include(c => c.CourseSections)
                    .ThenInclude(cs => cs.CourseSectionLecturers)
                    .ThenInclude(csl => csl.Lecturer)
                .FirstOrDefaultAsync(ap => ap.Name == academicPeriodName);
        }

        public async Task<List<Student>> GetStudentsForLecturer(int userId)
        {
            return await _dbContext.CourseSection
                .Where(cs =>
                    cs.CourseSectionLecturers.Any(css => css.Lecturer.SystemUserId == userId)
                )
                .SelectMany(x =>
                    x.CourseSectionStudents.Select(y => y.Student)
                )
                .Distinct()
                .Where(s => s.SystemUserId != userId)
                .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsForStudent(int userId)
        {
            return await _dbContext.CourseSection
                .Where(cs =>
                    cs.CourseSectionStudents.Any(css => css.Student.SystemUserId == userId)
                )
                .SelectMany(x => 
                    x.CourseSectionStudents.Select(y => y.Student)
                )
                .Distinct()
                .Where(s => s.SystemUserId != userId)
                .ToListAsync();
        }

        public async Task<List<CourseSection>> GetAllCourses(PaginationParams paginationParams, CancellationToken cancellationToken = default)
        {
            return await _dbContext.CourseSection
                .Include(cs => cs.CourseSectionStudents)
                .Include(cs => cs.AcademicPeriod)
                .Skip( (paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<AcademicPeriod?> GetFirstAcademicPeriod(CancellationToken cancellationToken = default)
        {
            return await _dbContext.AcademicPeriod.FirstOrDefaultAsync();
        }
    }
}
