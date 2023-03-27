using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unic.Infrastructure.Data.Migrations
{
    public partial class adding_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemUserId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemUserId",
                table: "Lecturer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_SystemUserId",
                table: "Student",
                column: "SystemUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_SystemUserId",
                table: "Lecturer",
                column: "SystemUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_SystemUser_SystemUserId",
                table: "Lecturer",
                column: "SystemUserId",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_SystemUser_SystemUserId",
                table: "Student",
                column: "SystemUserId",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_SystemUser_SystemUserId",
                table: "Lecturer");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_SystemUser_SystemUserId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropIndex(
                name: "IX_Student_SystemUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Lecturer_SystemUserId",
                table: "Lecturer");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "Lecturer");
        }
    }
}
