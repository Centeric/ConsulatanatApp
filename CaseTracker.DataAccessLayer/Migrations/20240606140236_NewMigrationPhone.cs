using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    public partial class NewMigrationPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Consultants");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Consultants",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Consultants");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
