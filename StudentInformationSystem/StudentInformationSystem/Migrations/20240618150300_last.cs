using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CollegeID",
                value: "2019980086");

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AcademicStatus", "ArabicName", "BirthDate", "CollegeID", "CollegeName", "CumulativeAverage", "DepartmentId", "Email", "EnglishName", "ForgetPasswordRequestOn", "GaduateStatus", "Gender", "ImagePath", "Nationality", "Password", "PlaceOfBirth", "SUbSpecilty", "Specilization", "UserName" },
                values: new object[] { 5L, "He studies", "حساب تجريبي", "18-06-2001", "2019980119", "Al-Hijjawi for Technological Engineering", null, 1L, "qaisihabnimer11@gmail.com", "Demo", null, "No", "male", "../../app-assets\\images\\portrait\\small\\avatar-s-11.jpg", "jordan", "Demo1@", "Aqaba", null, null, "Demo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CollegeID",
                value: "209980086");
        }
    }
}
