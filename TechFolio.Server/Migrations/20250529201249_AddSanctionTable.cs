using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFolio.Server.Migrations
{
    public partial class AddSanctionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Students",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "ProfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "Class");
        }
    }
}
