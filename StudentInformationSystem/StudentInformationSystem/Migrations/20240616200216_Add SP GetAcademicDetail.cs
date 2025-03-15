using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSPGetAcademicDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetAcademicDetail]
    @StudentId BIGINT
AS
BEGIN
    -- Temporary table to store the fetched data
    CREATE TABLE #MarksData (
        SemesterId INT,
        CourseId INT,
        StudentId BIGINT,
        Credits INT,
        FinalMarks DECIMAL(5, 2),
        MarksStatus NVARCHAR(50),
        AddedOn DATE,
        CourseName NVARCHAR(255),
        CourseCode NVARCHAR(50),
        CourseNumber NVARCHAR(50)
    );

    -- Fetch all necessary data
    INSERT INTO #MarksData
    SELECT 
        rc.SemesterId,
        rc.CourseId,
        rc.StudentId,
        c.Credits,
        m.FinalMarks,
        m.MarksStatus,
        rc.AddedOn,
        c.CourseName,
        c.CourseCode,
        c.CourseNumber
    FROM Marks m
    JOIN RegisteredCourses rc ON m.RegisteredCourseId = rc.Id
    JOIN Course c ON rc.CourseId = c.Id
    WHERE rc.StudentId = @StudentId;

    -- Calculate cumulative GPA
    DECLARE @TotalQualityPoints DECIMAL(10, 2), @TotalCreditHours INT, @TotalMarks DECIMAL(10, 2);
    SELECT 
        @TotalQualityPoints = SUM(FinalMarks * Credits),
        @TotalCreditHours = SUM(Credits),
        @TotalMarks = SUM(FinalMarks)
    FROM #MarksData;

    -- Temporary table to store semester GPA data
    CREATE TABLE #SemesterGPA (
        SemesterId INT,
        Year INT,
        GPA DECIMAL(5, 2),
        CreditHours INT
    );

    -- Calculate GPA for each semester
    INSERT INTO #SemesterGPA (SemesterId, Year, GPA, CreditHours)
    SELECT 
        SemesterId,
        YEAR(AddedOn) AS Year,
        SUM(FinalMarks * Credits) / SUM(Credits) AS GPA,
        SUM(Credits) AS CreditHours
    FROM #MarksData
    GROUP BY SemesterId, YEAR(AddedOn);

    -- Temporary table to store summary academic details
    CREATE TABLE #SummaryAcademicDetail (
        SemesterId INT,
        Year NVARCHAR(4),
        SemesterGPA DECIMAL(5, 2),
        NumberOfSemesterHours INT,
        TotalHoursStudiedByStudent INT,
        CumulativeGPA DECIMAL(5, 2)
    );

    -- Insert summary academic details
    INSERT INTO #SummaryAcademicDetail
    SELECT 
        sg.SemesterId,
        CAST(sg.Year AS NVARCHAR(4)),
        sg.GPA,
        sg.CreditHours,
        @TotalCreditHours,
        CASE WHEN @TotalCreditHours > 0 THEN @TotalQualityPoints / @TotalCreditHours ELSE 0 END
    FROM #SemesterGPA sg;

    -- Calculate total number of hours passed by the student
    DECLARE @TotalPassedHours INT;
    SELECT 
        @TotalPassedHours = SUM(Credits)
    FROM #MarksData
    WHERE MarksStatus = 'Pass';

    -- Select result to return
    SELECT 
        cad.CourseCode AS CourseCharacters,
        cad.CourseName,
        cad.CourseNumber,
        cad.Credits AS NumberOfHours,
        cad.FinalMarks AS Marks,
        cad.MarksStatus,
        cad.SemesterId AS Semester,
        YEAR(cad.AddedOn) AS Year
    FROM #MarksData cad;

    SELECT 
        SemesterId AS Semester,
        Year,
        SemesterGPA,
        NumberOfSemesterHours,
        TotalHoursStudiedByStudent,
        CumulativeGPA
    FROM #SummaryAcademicDetail;

    SELECT 
        @TotalCreditHours AS TotalCumulativeHours,
        CASE WHEN @TotalCreditHours > 0 THEN CAST(@TotalMarks / @TotalCreditHours AS INT) ELSE 0 END AS CumulativeAverage,
        @TotalMarks AS TotalCumulativeMarks,
        @TotalPassedHours AS TotalNumberOfHoursPassedByTheStudent;

    -- Clean up temporary tables
    DROP TABLE #MarksData;
    DROP TABLE #SemesterGPA;
    DROP TABLE #SummaryAcademicDetail;
END;");
          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
