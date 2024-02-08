using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuellt_databasprojekt.Migrations
{
    /// <inheritdoc />
    public partial class AddingforeignkeystoCourseStudentConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentConnection_CourseId",
                table: "CourseStudentConnection",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentConnection_Course_CourseId",
                table: "CourseStudentConnection",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentConnection_Student_StudentId",
                table: "CourseStudentConnection",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentConnection_Course_CourseId",
                table: "CourseStudentConnection");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentConnection_Student_StudentId",
                table: "CourseStudentConnection");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudentConnection_CourseId",
                table: "CourseStudentConnection");
        }
    }
}
