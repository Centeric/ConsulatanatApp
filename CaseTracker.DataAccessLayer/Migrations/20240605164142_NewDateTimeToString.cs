using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    public partial class NewDateTimeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextSteps_Consultants_ConsultantId1",
                table: "NextSteps");

            migrationBuilder.DropIndex(
                name: "IX_NextSteps_ConsultantId1",
                table: "NextSteps");

            migrationBuilder.DropColumn(
                name: "ConsultantId1",
                table: "NextSteps");

            migrationBuilder.AlterColumn<string>(
                name: "FilingDate",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DeadlineForDocumentSubmission",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfTransfer",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultantId1",
                table: "NextSteps",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FilingDate",
                table: "Consultants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeadlineForDocumentSubmission",
                table: "Consultants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfTransfer",
                table: "Consultants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextSteps_ConsultantId1",
                table: "NextSteps",
                column: "ConsultantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_NextSteps_Consultants_ConsultantId1",
                table: "NextSteps",
                column: "ConsultantId1",
                principalTable: "Consultants",
                principalColumn: "Id");
        }
    }
}
