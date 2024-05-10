using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawyerApp.DataAccessLayer.Migrations
{
    public partial class NextSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunicationUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CommunicationUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationUpdates_Consultants_Id",
                        column: x => x.Id,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NextStep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextSteps_Consultants_Id",
                        column: x => x.Id,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunicationUpdates");

            migrationBuilder.DropTable(
                name: "NextSteps");
        }
    }
}
