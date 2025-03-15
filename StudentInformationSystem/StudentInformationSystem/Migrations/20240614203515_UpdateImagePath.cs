using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ImagePath",
                value: "../../app-assets\\images\\portrait\\small\\avatar-s-11.jpg");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ImagePath",
                value: "../../app-assets\\images\\portrait\\small\\avatar-s-11.jpg");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ImagePath",
                value: "../../app-assets\\images\\portrait\\small\\avatar-s-11.jpg");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ImagePath",
                value: "../../app-assets\\images\\portrait\\small\\avatar-s-11.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ImagePath",
                value: "ImagePath");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ImagePath",
                value: "ImagePath");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ImagePath",
                value: "ImagePath");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ImagePath",
                value: "ImagePath");
        }
    }
}
