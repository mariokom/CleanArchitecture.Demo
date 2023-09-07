using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAD.Infrastructure.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FounderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmployeeType = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "FounderName", "Name" },
                values: new object[] { new Guid("b2ba841c-e1cf-40b9-9fbb-2a9f255e91fd"), "", "Odyssey" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "FounderName", "Name" },
                values: new object[] { new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"), "", "Microsoft" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CompanyId", "Name" },
                values: new object[,]
                {
                    { new Guid("70e49a93-363b-4fe1-a917-c82dbd55b794"), new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"), "Sales" },
                    { new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"), new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"), "Engineering" },
                    { new Guid("d837e96c-d5dc-44af-8cfb-c7c2819b4c8e"), new Guid("b2ba841c-e1cf-40b9-9fbb-2a9f255e91fd"), "Sales" },
                    { new Guid("da53d01a-5919-4022-85cc-db6031c5d6c2"), new Guid("fc21c2ce-89bb-4e57-b2d1-b3bf87abc62f"), "Marketing" },
                    { new Guid("f519991a-8f24-4d19-8446-7520d2c466fb"), new Guid("b2ba841c-e1cf-40b9-9fbb-2a9f255e91fd"), "Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "Email", "EmployeeType", "FirstName", "LastName", "Title" },
                values: new object[,]
                {
                    { new Guid("02a9e88c-6f55-4129-9978-1b7d5d1b5bf8"), new Guid("f519991a-8f24-4d19-8446-7520d2c466fb"), "e1@company.com", 1, "First1", "Last1", "junior" },
                    { new Guid("06e26235-164e-461b-9037-0ab8443a582c"), new Guid("d837e96c-d5dc-44af-8cfb-c7c2819b4c8e"), "e2@company.com", 1, "First2", "Last2", "junior" },
                    { new Guid("1b6c685d-201e-4bb5-926e-c0ba49a10db0"), new Guid("da53d01a-5919-4022-85cc-db6031c5d6c2"), "e8@company.com", 1, "First8", "Last8", "junior" },
                    { new Guid("2dbf7791-037d-4f55-bfc8-ad0628f47d88"), new Guid("f519991a-8f24-4d19-8446-7520d2c466fb"), "e0@company.com", 1, "First0", "Last0", "junior" },
                    { new Guid("31b89f85-037d-441c-975b-0b334068efed"), new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"), "e4@company.com", 1, "First4", "Last4", "junior" },
                    { new Guid("38308248-15bd-446d-89df-4c8aa40de2c7"), new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"), "e3@company.com", 1, "First3", "Last3", "junior" },
                    { new Guid("4f831249-fb08-4d27-82b4-c42b15647a76"), new Guid("70e49a93-363b-4fe1-a917-c82dbd55b794"), "e7@company.com", 1, "First7", "Last7", "junior" },
                    { new Guid("63de99af-5ba7-48f1-9f3d-6de8ef00afd5"), new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"), "e6@company.com", 1, "First6", "Last6", "junior" },
                    { new Guid("741574de-6d0a-4528-9b11-d5563c29ffc5"), new Guid("da53d01a-5919-4022-85cc-db6031c5d6c2"), "e9@company.com", 1, "First9", "Last9", "junior" },
                    { new Guid("e35396a9-01ba-43da-b3b9-f78dc0a7dde8"), new Guid("bc266937-a927-4dd7-ba07-8ecac7f3c0e1"), "e5@company.com", 1, "First5", "Last5", "junior" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_CompanyId",
                table: "Department",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
