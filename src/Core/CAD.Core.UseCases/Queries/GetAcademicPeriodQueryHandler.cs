using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Core.Shared.Queries;
using CAD.Domain.Entities;

namespace CAD.Core.UseCases.Queries
{
    public class GetAcademicPeriodQueryHandler : IRequestHandler<GetAcademicPeriodQuery, AcademicPeriodModel>
    {
        private readonly IUniversityRepository _universityRepository;

        public GetAcademicPeriodQueryHandler(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<AcademicPeriodModel> Handle(GetAcademicPeriodQuery request, CancellationToken cancellationToken)
        {
            AcademicPeriod? academicPeriod = await _universityRepository.GetAcademicPeriodAsync(request.AcademicPeriod, cancellationToken);
            if (academicPeriod == default)
            {
                return null;
            }

            return new AcademicPeriodModel
            {
                AcademicPeriod = academicPeriod.Name,
                Start = academicPeriod.Start,
                End = academicPeriod.End,
                Courses = academicPeriod?.CourseSections?.Select(cs =>
                    new CourseModel
                    {
                        CourseSectionTitle = cs.SectionTitle,
                        Lecturers = cs.CourseSectionLecturers?.Select(csl =>
                            new LecturerModel { FirstName = csl.Lecturer.FirstName, LastName = csl.Lecturer.LastName }
                        ).ToList()
                    }
                ).ToList()
            };

        }
    }
}
