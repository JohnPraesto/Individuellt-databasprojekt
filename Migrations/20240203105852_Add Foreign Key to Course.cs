using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuellt_databasprojekt.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeytoCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Course_EmployeeId",
                table: "Course",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Employee_EmployeeId",
                table: "Course",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Employee_EmployeeId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_EmployeeId",
                table: "Course");
        }
    }
}
