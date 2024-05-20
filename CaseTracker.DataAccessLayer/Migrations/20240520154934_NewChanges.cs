using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    public partial class NewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "NextSteps");

            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "CommunicationUpdates");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Consultants");

            migrationBuilder.AddColumn<int>(
                name: "ConsultationId",
                table: "NextSteps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultationId",
                table: "CommunicationUpdates",
                type: "int",
                nullable: true);
        }
    }
}
