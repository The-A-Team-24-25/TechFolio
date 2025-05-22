using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFolio.Server.Migrations
{
    public partial class AddStudentTypeIdToStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentTypes_StudentTypeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentTypeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentTypes_StudentTypeId",
                table: "Students",
                column: "StudentTypeId",
                principalTable: "StudentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentTypes_StudentTypeId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentTypeId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentTypes_StudentTypeId",
                table: "Students",
                column: "StudentTypeId",
                principalTable: "StudentTypes",
                principalColumn: "Id");
        }
    }
}
