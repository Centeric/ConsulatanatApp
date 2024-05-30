using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    public partial class NextStepCmmunications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConsultationId",
                table: "NextSteps",
                newName: "ConsultationsId");

            migrationBuilder.RenameColumn(
                name: "ConsultationId",
                table: "CommunicationUpdates",
                newName: "ConsultationsId");

            migrationBuilder.RenameColumn(
                name: "ConsultationId",
                table: "AttachmentModels",
                newName: "ConsultationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConsultationsId",
                table: "NextSteps",
                newName: "ConsultationId");

            migrationBuilder.RenameColumn(
                name: "ConsultationsId",
                table: "CommunicationUpdates",
                newName: "ConsultationId");

            migrationBuilder.RenameColumn(
                name: "ConsultationsId",
                table: "AttachmentModels",
                newName: "ConsultationId");
        }
    }
}
