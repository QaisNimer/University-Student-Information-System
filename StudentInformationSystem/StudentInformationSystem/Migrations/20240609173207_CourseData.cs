using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class CourseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (43, 1, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (47, 1, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (41, 1, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (44, 1, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (48, 1, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (42, 1, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (49, 1, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (50, 1, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (2, 1, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (3, 1, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (46, 1, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (51, 1, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (43, 2, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (47, 2, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (41, 2, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (44, 2, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (48, 2, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (42, 2, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (49, 2, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (50, 2, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (2, 2, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (3, 2, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (46, 2, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (51, 2, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (43, 3, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (47, 3, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (41, 3, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (44, 3, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (48, 3, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (42, 3, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (49, 3, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (50, 3, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (2, 3, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (3, 3, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (46, 3, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (51, 3, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (43, 4, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (47, 4, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (41, 4, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (44, 4, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (48, 4, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (42, 4, 1);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (49, 4, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (50, 4, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (2, 4, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (3, 4, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (46, 4, 2);
                    INSERT INTO RegisteredCourses (CourseId, StudentId, SemesterId) VALUES (51, 4, 2);
                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
