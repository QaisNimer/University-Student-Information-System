using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Marks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredCourseId = table.Column<long>(type: "bigint", nullable: false),
                    FirstMarks = table.Column<int>(type: "int", nullable: false),
                    SecondMarks = table.Column<int>(type: "int", nullable: false),
                    FinalMarks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_RegisteredCourses_RegisteredCourseId",
                        column: x => x.RegisteredCourseId,
                        principalTable: "RegisteredCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "FinalMarks", "FirstMarks", "RegisteredCourseId", "SecondMarks" },
                values: new object[,]
                {
                    { 1L, 88, 28, 1L, 28 },
                    { 2L, 80, 22, 2L, 22 },
                    { 3L, 90, 25, 3L, 25 },
                    { 4L, 100, 30, 4L, 30 },
                    { 5L, 84, 22, 5L, 22 },
                    { 6L, 78, 15, 6L, 15 },
                    { 7L, 80, 19, 7L, 19 },
                    { 8L, 66, 10, 8L, 10 },
                    { 9L, 88, 28, 9L, 28 },
                    { 10L, 80, 22, 10L, 22 },
                    { 11L, 90, 25, 11L, 25 },
                    { 12L, 100, 30, 12L, 30 },
                    { 13L, 84, 22, 13L, 22 },
                    { 14L, 78, 15, 14L, 15 },
                    { 15L, 80, 19, 15L, 19 },
                    { 16L, 66, 10, 16L, 10 },
                    { 17L, 88, 28, 17L, 28 },
                    { 18L, 80, 22, 18L, 22 },
                    { 19L, 90, 25, 19L, 25 },
                    { 20L, 100, 30, 20L, 30 },
                    { 21L, 84, 22, 21L, 22 },
                    { 22L, 78, 15, 22L, 15 },
                    { 23L, 80, 19, 23L, 19 },
                    { 24L, 66, 10, 24L, 10 },
                    { 25L, 88, 28, 25L, 28 },
                    { 26L, 80, 22, 26L, 22 },
                    { 27L, 90, 25, 27L, 25 },
                    { 28L, 100, 30, 28L, 30 },
                    { 29L, 84, 22, 29L, 22 },
                    { 30L, 78, 15, 30L, 15 },
                    { 31L, 80, 19, 31L, 19 },
                    { 32L, 66, 10, 32L, 10 },
                    { 33L, 88, 28, 33L, 28 },
                    { 34L, 80, 22, 34L, 22 },
                    { 35L, 90, 25, 35L, 25 },
                    { 36L, 100, 30, 36L, 30 },
                    { 37L, 84, 22, 37L, 22 },
                    { 38L, 78, 15, 38L, 15 },
                    { 39L, 80, 19, 39L, 19 },
                    { 40L, 66, 10, 40L, 10 },
                    { 41L, 88, 28, 41L, 28 },
                    { 42L, 80, 22, 42L, 22 },
                    { 43L, 90, 25, 43L, 25 },
                    { 44L, 100, 30, 44L, 30 },
                    { 45L, 84, 22, 45L, 22 },
                    { 46L, 78, 15, 46L, 15 },
                    { 47L, 80, 19, 47L, 19 },
                    { 48L, 66, 10, 48L, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_RegisteredCourseId",
                table: "Marks",
                column: "RegisteredCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");
        }
    }
}
