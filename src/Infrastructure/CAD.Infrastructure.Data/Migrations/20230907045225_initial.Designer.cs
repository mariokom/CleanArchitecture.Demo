﻿// <auto-generated />
using System;
using CAD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CAD.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20230907045225_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CAD.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FounderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b2ba841c-e1cf-40b9-9fbb-2a9f255e91fd"),
                            FounderName = "",
                            Name = "Odyssey"
                        },
                        new
                        {
                            Id = new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"),
                            FounderName = "",
                            Name = "Microsoft"
                        });
                });

            modelBuilder.Entity("CAD.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f519991a-8f24-4d19-8446-7520d2c466fb"),
                            CompanyId = new Guid("b2ba841c-e1cf-40b9-9fbb-2a9f255e91fd"),
                            Name = "Engineering"
                        },
                        new
                        {
                            Id = new Guid("d837e96c-d5dc-44af-8cfb-c7c2819b4c8e"),
                            CompanyId = new Guid("b2ba841c-e1cf-40b9-9fbb-2a9f255e91fd"),
                            Name = "Sales"
                        },
                        new
                        {
                            Id = new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"),
                            CompanyId = new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"),
                            Name = "Engineering"
                        },
                        new
                        {
                            Id = new Guid("70e49a93-363b-4fe1-a917-c82dbd55b794"),
                            CompanyId = new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"),
                            Name = "Sales"
                        },
                        new
                        {
                            Id = new Guid("da53d01a-5919-4022-85cc-db6031c5d6c2"),
                            CompanyId = new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"),
                            Name = "Marketing"
                        });
                });

            modelBuilder.Entity("CAD.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("EmployeeType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2dbf7791-037d-4f55-bfc8-ad0628f47d88"),
                            DepartmentId = new Guid("f519991a-8f24-4d19-8446-7520d2c466fb"),
                            Email = "e0@company.com",
                            EmployeeType = 1,
                            FirstName = "First0",
                            LastName = "Last0",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("02a9e88c-6f55-4129-9978-1b7d5d1b5bf8"),
                            DepartmentId = new Guid("f519991a-8f24-4d19-8446-7520d2c466fb"),
                            Email = "e1@company.com",
                            EmployeeType = 1,
                            FirstName = "First1",
                            LastName = "Last1",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("06e26235-164e-461b-9037-0ab8443a582c"),
                            DepartmentId = new Guid("d837e96c-d5dc-44af-8cfb-c7c2819b4c8e"),
                            Email = "e2@company.com",
                            EmployeeType = 1,
                            FirstName = "First2",
                            LastName = "Last2",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("38308248-15bd-446d-89df-4c8aa40de2c7"),
                            DepartmentId = new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"),
                            Email = "e3@company.com",
                            EmployeeType = 1,
                            FirstName = "First3",
                            LastName = "Last3",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("31b89f85-037d-441c-975b-0b334068efed"),
                            DepartmentId = new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"),
                            Email = "e4@company.com",
                            EmployeeType = 1,
                            FirstName = "First4",
                            LastName = "Last4",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("e35396a9-01ba-43da-b3b9-f78dc0a7dde8"),
                            DepartmentId = new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"),
                            Email = "e5@company.com",
                            EmployeeType = 1,
                            FirstName = "First5",
                            LastName = "Last5",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("63de99af-5ba7-48f1-9f3d-6de8ef00afd5"),
                            DepartmentId = new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"),
                            Email = "e6@company.com",
                            EmployeeType = 1,
                            FirstName = "First6",
                            LastName = "Last6",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("4f831249-fb08-4d27-82b4-c42b15647a76"),
                            DepartmentId = new Guid("70e49a93-363b-4fe1-a917-c82dbd55b794"),
                            Email = "e7@company.com",
                            EmployeeType = 1,
                            FirstName = "First7",
                            LastName = "Last7",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("1b6c685d-201e-4bb5-926e-c0ba49a10db0"),
                            DepartmentId = new Guid("da53d01a-5919-4022-85cc-db6031c5d6c2"),
                            Email = "e8@company.com",
                            EmployeeType = 1,
                            FirstName = "First8",
                            LastName = "Last8",
                            Title = "junior"
                        },
                        new
                        {
                            Id = new Guid("741574de-6d0a-4528-9b11-d5563c29ffc5"),
                            DepartmentId = new Guid("da53d01a-5919-4022-85cc-db6031c5d6c2"),
                            Email = "e9@company.com",
                            EmployeeType = 1,
                            FirstName = "First9",
                            LastName = "Last9",
                            Title = "junior"
                        });
                });

            modelBuilder.Entity("CAD.Domain.Entities.Department", b =>
                {
                    b.HasOne("CAD.Domain.Entities.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CAD.Domain.Entities.Employee", b =>
                {
                    b.HasOne("CAD.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CAD.Domain.Entities.Company", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("CAD.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}