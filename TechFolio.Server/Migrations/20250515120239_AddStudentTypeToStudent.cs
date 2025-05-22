using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFolio.Server.Migrations
{
    public partial class AddStudentTypeToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentTypeId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentTypeId",
                table: "Students",
                column: "StudentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentTypes_StudentTypeId",
                table: "Students",
                column: "StudentTypeId",
                principalTable: "StudentTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentTypes_StudentTypeId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentTypeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentTypeId",
                table: "Students");
        }
    }
}
