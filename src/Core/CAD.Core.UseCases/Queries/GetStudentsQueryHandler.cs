﻿using MediatR;
using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Models;
using CAD.Core.Shared.Queries;
using CAD.Core.TokenAuthorization;
using CAD.Domain.Entities;

namespace CAD.Core.UseCases.Queries
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentModel>>
    {
        private readonly IUniversityRepository _universityRepo;
        private readonly AuthorizationContext _authorizationContext;

        public GetStudentsQueryHandler(IUniversityRepository universityRepository,
            AuthorizationContext authorizationContext) 
        {
            _universityRepo = universityRepository;
            _authorizationContext = authorizationContext;
        }

        public async Task<List<StudentModel>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            Enum.TryParse(_authorizationContext.UserRole, out UserRole userRole);

            List<StudentModel> students;
            if (userRole == UserRole.Lecturer)
            {
                students = ConvertToStudentModelForLecturer(
                    await _universityRepo.GetStudentsForLecturer(_authorizationContext.UserId)
                );
            }
            else
            {
                students = ConvertToStudentModelForStudent(
                    await _universityRepo.GetStudentsForStudent(_authorizationContext.UserId)
                );
            }
            return await Task.FromResult(students);
        }

        private List<StudentModel> ConvertToStudentModelForLecturer(List<Student> students)
        {
            return students.Select(student => new StudentModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email= student.Email,
                Phone = student.Phone
            }).ToList();
        }

        private List<StudentModel> ConvertToStudentModelForStudent(List<Student> students)
        {
            return students.Select(student => new StudentModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            }).ToList();
        }
    }
}
