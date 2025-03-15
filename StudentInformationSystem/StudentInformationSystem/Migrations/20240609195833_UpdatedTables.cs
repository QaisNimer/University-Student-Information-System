using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudyPlanId",
                table: "Course",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "StudyPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyPlanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlan", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "ELE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "ELE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "ELE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CME", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CME", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CME", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CME", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "EPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "EPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "EPE", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CHEM", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "CHEM", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "MATH", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "MATH", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "MATH", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "MATH", 2L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "PHYS", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "PHYS", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "PHYS", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "PHYS", 4L });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 51L,
                columns: new[] { "CourseCode", "StudyPlanId" },
                values: new object[] { "BME", 4L });

            migrationBuilder.InsertData(
                table: "StudyPlan",
                columns: new[] { "Id", "StudyPlanName" },
                values: new object[,]
                {
                    { 1L, "Compulsory university" },
                    { 2L, "Compulsory section" },
                    { 3L, "Optional university" },
                    { 4L, "Compulsory college" },
                    { 5L, "Elective department" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCourses_CourseId",
                table: "RegisteredCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCourses_SemesterId",
                table: "RegisteredCourses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCourses_StudentId",
                table: "RegisteredCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudyPlanId",
                table: "Course",
                column: "StudyPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_StudyPlan_StudyPlanId",
                table: "Course",
                column: "StudyPlanId",
                principalTable: "StudyPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredCourses_Course_CourseId",
                table: "RegisteredCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredCourses_Semester_SemesterId",
                table: "RegisteredCourses",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredCourses_Student_StudentId",
                table: "RegisteredCourses",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_StudyPlan_StudyPlanId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredCourses_Course_CourseId",
                table: "RegisteredCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredCourses_Semester_SemesterId",
                table: "RegisteredCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredCourses_Student_StudentId",
                table: "RegisteredCourses");

            migrationBuilder.DropTable(
                name: "StudyPlan");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredCourses_CourseId",
                table: "RegisteredCourses");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredCourses_SemesterId",
                table: "RegisteredCourses");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredCourses_StudentId",
                table: "RegisteredCourses");

            migrationBuilder.DropIndex(
                name: "IX_Course_StudyPlanId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "StudyPlanId",
                table: "Course");

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 34L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 35L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 36L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 37L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 38L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 39L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 41L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 42L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 43L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 44L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 45L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 46L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 47L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 48L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 49L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 50L,
                column: "CourseCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 51L,
                column: "CourseCode",
                value: null);
        }
    }
}
