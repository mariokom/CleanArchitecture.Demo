using Microsoft.EntityFrameworkCore;
using Unic.Domain.Entities;
using Unic.Infrastructure.Data.EntityConfigurations;

namespace Unic.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LecturerConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new CourseSectionConfiguration());
            modelBuilder.ApplyConfiguration(new CourseSectionLecturerConfiguration());
            modelBuilder.ApplyConfiguration(new CourseSectionStudentConfiguration());
            modelBuilder.ApplyConfiguration(new SystemUserConfiguration());
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseSection> CourseSection { get; set; }
        public DbSet<AcademicPeriod> AcademicPeriod { get; set; }

        public DbSet<SystemUser> SystemUser { get; set; }

    }
}
