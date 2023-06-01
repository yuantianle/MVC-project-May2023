using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnboardingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeStatusLookUps_EmployeeStatusLookUpId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeStatusLookUpId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeStatusLookUpId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeStatusLookUpId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusLookUpId",
                table: "Employees",
                column: "EmployeeStatusLookUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeStatusLookUps_EmployeeStatusLookUpId",
                table: "Employees",
                column: "EmployeeStatusLookUpId",
                principalTable: "EmployeeStatusLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
