using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFolio.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleEnumFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "AspNetUsers");
        }
    }
}
