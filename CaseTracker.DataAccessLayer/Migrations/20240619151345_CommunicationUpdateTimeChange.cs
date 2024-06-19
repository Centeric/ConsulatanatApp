using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    public partial class CommunicationUpdateTimeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommunicatioUpdateTime",
                table: "CommunicationUpdates",
                newName: "CommunicationUpdateTime");

       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommunicationUpdateTime",
                table: "CommunicationUpdates",
                newName: "CommunicatioUpdateTime");

        }
    }
}
