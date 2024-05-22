using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    public partial class UpdateNotificationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationTime",
                table: "Notifications",
                newName: "NotificationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationDate",
                table: "Notifications",
                newName: "NotificationTime");
        }
    }
}
