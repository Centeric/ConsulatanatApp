using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawyerApp.DataAccessLayer.Migrations
{
    public partial class InitialEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeShare = table.Column<double>(type: "float", nullable: false),
                    PaymentReceived = table.Column<bool>(type: "bit", nullable: false),
                    LeadConsultant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantConsultant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HearingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineForDocumentSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfTransfer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultants");
        }
    }
}
