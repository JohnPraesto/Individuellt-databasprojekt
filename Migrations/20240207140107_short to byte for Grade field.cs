using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuellt_databasprojekt.Migrations
{
    /// <inheritdoc />
    public partial class shorttobyteforGradefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Grade",
                table: "CourseStudentConnection",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Grade",
                table: "CourseStudentConnection",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }
    }
}
