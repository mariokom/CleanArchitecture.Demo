using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unic.Infrastructure.Data.Migrations
{
    public partial class adding_salt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "SystemUser");
        }
    }
}
