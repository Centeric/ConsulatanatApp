using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawyerApp.DataAccessLayer.Migrations
{
    public partial class CaseSummmary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaseSummary",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseSummary",
                table: "Consultants");
        }
    }
}
