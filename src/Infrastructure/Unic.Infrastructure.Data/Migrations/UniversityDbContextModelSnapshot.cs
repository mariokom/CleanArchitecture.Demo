﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unic.Infrastructure.Data;

#nullable disable

namespace Unic.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class UniversityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Unic.Domain.Entities.AcademicPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AcademicPeriod");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Unic.Domain.Entities.CourseSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AcademicPeriodId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("SectionTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AcademicPeriodId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseSection");
                });

            modelBuilder.Entity("Unic.Domain.Entities.CourseSectionLecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("CourseSectionId")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "CourseSectionId");

                    b.HasIndex("CourseSectionId");

                    b.ToTable("CourseSectionLecturer");
                });

            modelBuilder.Entity("Unic.Domain.Entities.CourseSectionStudent", b =>
                {
                    b.Property<int>("StudentlId")
                        .HasColumnType("int");

                    b.Property<int>("CourseSectionId")
                        .HasColumnType("int");

                    b.HasKey("StudentlId", "CourseSectionId");

                    b.HasIndex("CourseSectionId");

                    b.ToTable("CourseSectionStudent");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SocialInsuranceNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SystemUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SystemUserId")
                        .IsUnique();

                    b.ToTable("Lecturer");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SystemUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SystemUserId")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Unic.Domain.Entities.SystemUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("SystemUser");
                });

            modelBuilder.Entity("Unic.Domain.Entities.CourseSection", b =>
                {
                    b.HasOne("Unic.Domain.Entities.AcademicPeriod", "AcademicPeriod")
                        .WithMany("CourseSections")
                        .HasForeignKey("AcademicPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unic.Domain.Entities.Course", "Course")
                        .WithMany("CourseSections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicPeriod");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Unic.Domain.Entities.CourseSectionLecturer", b =>
                {
                    b.HasOne("Unic.Domain.Entities.CourseSection", "CourseSection")
                        .WithMany("CourseSectionLecturers")
                        .HasForeignKey("CourseSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unic.Domain.Entities.Lecturer", "Lecturer")
                        .WithMany("CourseSectionLecturers")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSection");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("Unic.Domain.Entities.CourseSectionStudent", b =>
                {
                    b.HasOne("Unic.Domain.Entities.CourseSection", "CourseSection")
                        .WithMany("CourseSectionStudents")
                        .HasForeignKey("CourseSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unic.Domain.Entities.Student", "Student")
                        .WithMany("CourseSectionStudents")
                        .HasForeignKey("StudentlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSection");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Lecturer", b =>
                {
                    b.HasOne("Unic.Domain.Entities.SystemUser", "SystemUser")
                        .WithOne()
                        .HasForeignKey("Unic.Domain.Entities.Lecturer", "SystemUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Student", b =>
                {
                    b.HasOne("Unic.Domain.Entities.SystemUser", "SystemUser")
                        .WithOne()
                        .HasForeignKey("Unic.Domain.Entities.Student", "SystemUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("Unic.Domain.Entities.AcademicPeriod", b =>
                {
                    b.Navigation("CourseSections");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Course", b =>
                {
                    b.Navigation("CourseSections");
                });

            modelBuilder.Entity("Unic.Domain.Entities.CourseSection", b =>
                {
                    b.Navigation("CourseSectionLecturers");

                    b.Navigation("CourseSectionStudents");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Lecturer", b =>
                {
                    b.Navigation("CourseSectionLecturers");
                });

            modelBuilder.Entity("Unic.Domain.Entities.Student", b =>
                {
                    b.Navigation("CourseSectionStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
