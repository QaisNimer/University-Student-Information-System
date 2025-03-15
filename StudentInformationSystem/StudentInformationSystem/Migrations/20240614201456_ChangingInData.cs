using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangingInData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "RegisteredCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MarksStatus",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"Delete from RegisteredCourses");

            migrationBuilder.Sql(@"INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId, AddedOn) VALUES
 (43, 1, 1, '2024/1/1'),
 (47, 1, 1, '2024/1/1'),
 (41, 1, 1, '2024/1/1'),
 (44, 1, 1, '2024/1/1'),
 (48, 1, 1, '2024/1/1'),
 (42, 1, 1, '2024/1/1'),
(49, 1, 3, '2023/3/1'),
(50, 1, 3, '2023/3/1'),
 (2, 1, 3, '2023/3/1'),
 (3, 1, 3, '2023/3/1'),
(46, 1, 3, '2023/3/1'),
(51, 1, 3, '2023/3/1'),
(43, 1, 2, '2023/2/1'),
(47, 1, 2, '2023/2/1'),
(41, 1, 2, '2023/2/1'),
(44, 1, 2, '2023/2/1'),
(48, 1, 2, '2023/2/1'),
(42, 1, 2, '2023/2/1'),
 (43, 2, 1, '2024/1/1'),
 (47, 2, 1, '2024/1/1'),
 (41, 2, 1, '2024/1/1'),
 (44, 2, 1, '2024/1/1'),
 (48, 2, 1, '2024/1/1'),
 (42, 2, 1, '2024/1/1'),
(49, 2, 3, '2023/3/1'),
(50, 2, 3, '2023/3/1'),
 (2, 2, 3, '2023/3/1'),
 (3, 2, 3, '2023/3/1'),
(46, 2, 3, '2023/3/1'),
(51, 2, 3, '2023/3/1'),
(43, 2, 2, '2023/2/1'),
(47, 2, 2, '2023/2/1'),
(41, 2, 2, '2023/2/1'),
(44, 2, 2, '2023/2/1'),
(48, 2, 2, '2023/2/1'),
(42, 2, 2, '2023/2/1'),
 (43, 3, 1, '2024/1/1'),
 (47, 3, 1, '2024/1/1'),
 (41, 3, 1, '2024/1/1'),
 (44, 3, 1, '2024/1/1'),
 (48, 3, 1, '2024/1/1'),
 (42, 3, 1, '2024/1/1'),
(49, 3, 3, '2023/3/1'),
(50, 3, 3, '2023/3/1'),
 (2, 3, 3, '2023/3/1'),
 (3, 3, 3, '2023/3/1'),
(46, 3, 3, '2023/3/1'),
(51, 3, 3, '2023/3/1'),
(43, 3, 2, '2023/2/1'),
(47, 3, 2, '2023/2/1'),
(41, 3, 2, '2023/2/1'),
(44, 3, 2, '2023/2/1'),
(48, 3, 2, '2023/2/1'),
(42, 3, 2, '2023/2/1'),
 (43, 4, 1, '2024/1/1'),
 (47, 4, 1, '2024/1/1'),
 (41, 4, 1, '2024/1/1'),
 (44, 4, 1, '2024/1/1'),
 (48, 4, 1, '2024/1/1'),
 (42, 4, 1, '2024/1/1'),
(49, 4, 3, '2023/3/1'),
(50, 4, 3, '2023/3/1'),
 (2, 4, 3, '2023/3/1'),
 (3, 4, 3, '2023/3/1'),
(46, 4, 3, '2023/3/1'),
(51, 4, 3, '2023/3/1'),
(43, 4, 2, '2023/2/1'),
(47, 4, 2, '2023/2/1'),
(41, 4, 2, '2023/2/1'),
(44, 4, 2, '2023/2/1'),
(48, 4, 2, '2023/2/1'),
(42, 4, 2, '2023/2/1');
");


            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 24, "Pass", 24 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "FirstMarks", "MarksStatus" },
                values: new object[] { 15, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 25, "Pass", 25 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 66, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 48, "Failed" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 21, "Pass", 21 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 10L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 100, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "FinalMarks", "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 67, 10, "Pass", 17 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 13L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 66, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 50, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 45, "Failed" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 21, "Pass", 23 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 18L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 100, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "FinalMarks", "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 35, 5, "Failed", 9 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 21L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 66, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 23L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 43, "Failed" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "FinalMarks", "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 78, 19, "Pass", 14 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 26L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 27L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 25, "Pass", 25 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 29L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 66, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 31L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 44, "Failed" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "FinalMarks", "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 52, 14, "Pass", 12 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 34L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 100, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "FinalMarks", "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 36, 7, "Failed", 14 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 37L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 66, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 39L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 42, "Failed" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "FinalMarks", "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 55, 5, "Pass", 1 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 42L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 100, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "FinalMarks", "FirstMarks", "MarksStatus", "SecondMarks" },
                values: new object[] { 55, 6, "Pass", 12 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 45L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 66, "Pass" });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 47L,
                column: "MarksStatus",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "FinalMarks", "MarksStatus" },
                values: new object[] { 35, "Failed" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "FinalMarks", "FirstMarks", "MarksStatus", "RegisteredCourseId", "SecondMarks" },
                values: new object[,]
                {
                    { 49L, 88, 22, "Pass", 49L, 20 },
                    { 50L, 35, 13, "Failed", 50L, 0 },
                    { 51L, 70, 25, "Pass", 51L, 23 },
                    { 52L, 50, 11, "Pass", 52L, 11 },
                    { 53L, 75, 23, "Pass", 53L, 14 },
                    { 54L, 64, 14, "Pass", 54L, 16 },
                    { 55L, 47, 19, "Failed", 55L, 18 },
                    { 56L, 42, 14, "Failed", 56L, 19 },
                    { 57L, 61, 15, "Pass", 57L, 17 },
                    { 58L, 90, 24, "Pass", 58L, 21 },
                    { 59L, 90, 21, "Pass", 59L, 20 },
                    { 60L, 80, 20, "Pass", 60L, 20 },
                    { 61L, 53, 0, "Pass", 61L, 20 },
                    { 62L, 47, 23, "Failed", 62L, 19 },
                    { 63L, 39, 11, "Failed", 63L, 10 },
                    { 64L, 50, 14, "Pass", 64L, 1 },
                    { 65L, 41, 16, "Failed", 65L, 22 },
                    { 66L, 86, 18, "Pass", 66L, 25 },
                    { 67L, 74, 19, "Pass", 67L, 12 },
                    { 68L, 73, 17, "Pass", 68L, 22 },
                    { 69L, 68, 21, "Pass", 69L, 19 },
                    { 70L, 80, 20, "Pass", 70L, 10 },
                    { 71L, 59, 20, "Pass", 71L, 1 },
                    { 72L, 81, 20, "Pass", 72L, 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "RegisteredCourses");

            migrationBuilder.DropColumn(
                name: "MarksStatus",
                table: "Marks");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstMarks", "SecondMarks" },
                values: new object[] { 28, 28 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FirstMarks",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "FirstMarks", "SecondMarks" },
                values: new object[] { 30, 30 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FinalMarks",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FinalMarks",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "FirstMarks", "SecondMarks" },
                values: new object[] { 28, 28 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "FinalMarks",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "FinalMarks", "FirstMarks", "SecondMarks" },
                values: new object[] { 100, 30, 30 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 14L,
                column: "FinalMarks",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 15L,
                column: "FinalMarks",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 16L,
                column: "FinalMarks",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "FirstMarks", "SecondMarks" },
                values: new object[] { 28, 28 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 19L,
                column: "FinalMarks",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "FinalMarks", "FirstMarks", "SecondMarks" },
                values: new object[] { 100, 30, 30 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 22L,
                column: "FinalMarks",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 24L,
                column: "FinalMarks",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "FinalMarks", "FirstMarks", "SecondMarks" },
                values: new object[] { 88, 28, 28 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "FirstMarks", "SecondMarks" },
                values: new object[] { 30, 30 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 30L,
                column: "FinalMarks",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 32L,
                column: "FinalMarks",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "FinalMarks", "FirstMarks", "SecondMarks" },
                values: new object[] { 88, 28, 28 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 35L,
                column: "FinalMarks",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "FinalMarks", "FirstMarks", "SecondMarks" },
                values: new object[] { 100, 30, 30 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 38L,
                column: "FinalMarks",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 40L,
                column: "FinalMarks",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "FinalMarks", "FirstMarks", "SecondMarks" },
                values: new object[] { 88, 28, 28 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 43L,
                column: "FinalMarks",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "FinalMarks", "FirstMarks", "SecondMarks" },
                values: new object[] { 100, 30, 30 });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 46L,
                column: "FinalMarks",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 48L,
                column: "FinalMarks",
                value: 66);
        }
    }
}
