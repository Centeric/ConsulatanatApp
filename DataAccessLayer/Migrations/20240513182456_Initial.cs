using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawyerApp.DataAccessLayer.Migrations
{
    public partial class Initial : Migration
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
                    TimeShareName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeShare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReceived = table.Column<bool>(type: "bit", nullable: false),
                    LeadConsultant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantConsultant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HearingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineForDocumentSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfTransfer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseSummary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationUpdates",
                columns: table => new
                {
                    CommunicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationUpdates", x => x.CommunicationId);
                    table.ForeignKey(
                        name: "FK_CommunicationUpdates_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextSteps",
                columns: table => new
                {
                    NextStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NextStep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextSteps", x => x.NextStepId);
                    table.ForeignKey(
                        name: "FK_NextSteps_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationUpdates_ConsultantId",
                table: "CommunicationUpdates",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_NextSteps_ConsultantId",
                table: "NextSteps",
                column: "ConsultantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunicationUpdates");

            migrationBuilder.DropTable(
                name: "NextSteps");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Consultants");
        }
    }
}
