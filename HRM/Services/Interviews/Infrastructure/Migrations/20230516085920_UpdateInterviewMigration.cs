using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInterviewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypeLookUps_InterviewTypeLookUpId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropTable(
                name: "Interviewers");

            migrationBuilder.DropTable(
                name: "InterviewTypeLookUps");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewTypeLookUpId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "InterviewTypeLookUpId",
                table: "Interviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeLookUpId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Interviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeIdentityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewTypeLookUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InterviewTypeDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewTypeLookUps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewTypeLookUpId",
                table: "Interviews",
                column: "InterviewTypeLookUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypeLookUps_InterviewTypeLookUpId",
                table: "Interviews",
                column: "InterviewTypeLookUpId",
                principalTable: "InterviewTypeLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
