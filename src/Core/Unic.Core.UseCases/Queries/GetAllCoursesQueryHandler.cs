﻿using MediatR;
using Unic.Core.Shared.Interfaces;
using Unic.Core.Shared.Models;
using Unic.Core.Shared.Queries;
using Unic.Core.TokenAuthorization;
using Unic.Domain.Entities;

namespace Unic.Core.UseCases.Queries
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
