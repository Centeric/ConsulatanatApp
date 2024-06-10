using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    public partial class CreateDateNewDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Consultants");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Consultants",
                type: "datetime",
                nullable: false,
               defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Consultants");

            migrationBuilder.AddColumn<string>(
                name: "CreateDate",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
