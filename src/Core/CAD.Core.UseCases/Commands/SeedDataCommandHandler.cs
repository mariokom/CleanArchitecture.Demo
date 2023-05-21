using MediatR;
using System.Net.Http.Headers;
using CAD.Core.Shared.Commands;
using CAD.Core.Shared.Interfaces;
using CAD.Core.Shared.Queries;
using CAD.Domain.Entities;

namespace CAD.Core.UseCases.Commands
{
    public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand, Unit>
    {
        private readonly IHashManager _hashManager;

        public IUniversityRepository _universityRepository { get; set; }

        public SeedDataCommandHandler(IUniversityRepository universityRepository, IHashManager hashManager)
        {
            _universityRepository = universityRepository;
            _hashManager = hashManager;
        }

        public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            AcademicPeriod academicPeriod = await _universityRepository.GetFirstAcademicPeriod();
            if (academicPeriod != null)
            {
                return await Unit.Task;
            }

            //courses
            Course programming = new Course { Title = "Programming" };
            Course networks = new Course { Title = "Networks" };
            Course dataStructures = new Course { Title = "Data Structures" };
            Course math = new Course { Title = "Math" };

            //students
            string salt = _hashManager.CreateSalt();
            string password = _hashManager.Hash("12345", salt);
            Student johnStudent = new Student { 
                FirstName = "John", LastName = "Doe", Phone = "555-1234", Email = "john@example.com", 
                SystemUser = new SystemUser { Username = "john", Password = password, PasswordSalt = salt, Role = UserRole.Student } 
            };

            salt = _hashManager.CreateSalt();
            password = _hashManager.Hash("12345", salt);
            Student janeStudent = new Student { 
                FirstName = "Jane", LastName = "Doe", Phone = "555-5678", Email = "jane@example.com", 
                SystemUser = new SystemUser { Username = "jane", Password = password, PasswordSalt = salt, Role = UserRole.Student } 
            };

            salt = _hashManager.CreateSalt();
            password = _hashManager.Hash("12345", salt);
            Student aliceStudent = new Student { 
                FirstName = "Alice", LastName = "Smith", Phone = "555-2468", Email = "alice@example.com", 
                SystemUser = new SystemUser { Username = "alice", Password = password, PasswordSalt = salt, Role = UserRole.Student } 
            };

            salt = _hashManager.CreateSalt();
            password = _hashManager.Hash("12345", salt);
            Student bobStudent = new Student {
                FirstName = "Bob", LastName = "Johnson", Phone = "555-1357", Email = "bob@example.com", 
                SystemUser = new SystemUser { Username = "bob", Password = password, PasswordSalt = salt, Role = UserRole.Student } 
            };

            salt = _hashManager.CreateSalt();
            password = _hashManager.Hash("12345", salt);
            Student charlieStudent = new Student { 
                FirstName = "Charlie", LastName = "Brown", Phone = "555-7890", Email = "charlie@example.com", 
                SystemUser = new SystemUser { Username = "charlie", Password = password, PasswordSalt = salt, Role = UserRole.Student } 
            };

            //lecturels
            salt = _hashManager.CreateSalt();
            password = _hashManager.Hash("12345", salt);
            Lecturer markLecturer = new Lecturer { 
                FirstName = "Mark", LastName = "McMark", SocialInsuranceNumber = "123-45-6780", 
                SystemUser = new SystemUser { Username = "mark", Password = password, PasswordSalt = salt, Role = UserRole.Lecturer } 
            };

            salt = _hashManager.CreateSalt();
            password = _hashManager.Hash("12345", salt);
            Lecturer kevinLecturer = new Lecturer { 
                FirstName = "Kevin", LastName = "McKevin", SocialInsuranceNumber = "123-45-6781", 
                SystemUser = new SystemUser { Username = "kevin", Password = password, PasswordSalt = salt  , Role = UserRole.Lecturer } 
            };

            salt = _hashManager.CreateSalt();
            password = _hashManager.Hash("12345", salt);
            Lecturer ericLecturer = new Lecturer { 
                FirstName = "Eric", LastName = "McEric", SocialInsuranceNumber = "123-45-6781", 
                SystemUser = new SystemUser { Username = "eric", Password = password, PasswordSalt = salt, Role = UserRole.Lecturer } 
            };

            //periods
            AcademicPeriod fall23 = new AcademicPeriod {
                Name = "Fall 2023",
                Start = new DateTime(2023, 9, 1),
                End = new DateTime(2023, 12, 20),
                CourseSections = new List<CourseSection>() 
                {
                    new CourseSection
                    {
                        SectionTitle = "Programming 1",
                        Course = programming,
                        CourseSectionLecturers = ConvertLecturers(markLecturer, kevinLecturer),
                        CourseSectionStudents = ConvertStudents(johnStudent, janeStudent)
                    },
                    new CourseSection
                    {
                        SectionTitle = "Programming 2",
                        Course = programming,
                        CourseSectionLecturers = ConvertLecturers(markLecturer),
                        CourseSectionStudents = ConvertStudents(johnStudent, janeStudent)
                    },
                    new CourseSection
                    {
                        SectionTitle = "Networks 1",
                        Course = networks,
                        CourseSectionLecturers = ConvertLecturers(kevinLecturer),
                        CourseSectionStudents = ConvertStudents(bobStudent, charlieStudent)
                    },
                    new CourseSection
                    {
                        SectionTitle = "Data structures 1",
                        Course = dataStructures,
                        CourseSectionLecturers = ConvertLecturers(ericLecturer),
                        CourseSectionStudents = ConvertStudents(aliceStudent, bobStudent)
                    }
                }
            };

            AcademicPeriod spring23 = new AcademicPeriod
            {
                Name = "Spring 2024",
                Start = new DateTime(2024, 1, 20),
                End = new DateTime(2024, 06, 1),
                CourseSections = new List<CourseSection>()
                {
                    new CourseSection
                    {
                        SectionTitle = "Networks 2",
                        Course = networks,
                        CourseSectionLecturers = ConvertLecturers(kevinLecturer),
                        CourseSectionStudents = ConvertStudents(bobStudent, charlieStudent)
                    },
                    new CourseSection
                    {
                        SectionTitle = "Math 1",
                        Course = math,
                        CourseSectionLecturers = ConvertLecturers(ericLecturer, markLecturer),
                        CourseSectionStudents = ConvertStudents(aliceStudent, charlieStudent)
                    }
                }
            };

            await _universityRepository.AddAcademicPeriodAsync(fall23);
            await _universityRepository.AddAcademicPeriodAsync(spring23);

            return Unit.Value;
        }
    
        private static List<CourseSectionLecturer> ConvertLecturers(params Lecturer[] lecturers)
        {
            return lecturers.Select(
                l => new CourseSectionLecturer { Lecturer = l }
            ).ToList();
        }

        private static List<CourseSectionStudent> ConvertStudents(params Student[] students)
        {
            return students.Select(
                s => new CourseSectionStudent { Student = s }
            ).ToList();
        }
    }
}
