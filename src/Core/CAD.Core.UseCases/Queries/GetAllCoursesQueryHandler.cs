using MediatR;
using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Core.Shared.Queries;
using CAD.Core.TokenAuthorization;
using CAD.Domain.Entities;

namespace CAD.Core.UseCases.Queries
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseModel>>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly AuthorizationContext _authorizationContext;

        public GetAllCoursesQueryHandler(IUniversityRepository universityRepository,
            AuthorizationContext authorizationContext)
        {
            _universityRepository = universityRepository;
            _authorizationContext = authorizationContext;
        }

        public async Task<List<CourseModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            Enum.TryParse(_authorizationContext.UserRole, out UserRole userRole);

            List<CourseSection> courseSections = await _universityRepository.GetAllCourses(
                request.PaginationParams, cancellationToken
            );

            List<CourseModel> courseModels = courseSections.Select(cs => 
                new CourseModel
                {
                    CourseSectionTitle = $"{cs.SectionTitle} ({cs.AcademicPeriod.Name})",
                    TotalStudents = (userRole == UserRole.Lecturer) ? cs.CourseSectionStudents.Count : null
                }
            ).ToList();

            return await Task.FromResult(courseModels);
        }
    }
}
