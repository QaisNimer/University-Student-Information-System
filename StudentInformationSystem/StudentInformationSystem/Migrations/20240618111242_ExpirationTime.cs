using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class ExpirationTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ForgetPasswordRequestOn",
                table: "Student",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ForgetPasswordRequestOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ForgetPasswordRequestOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ForgetPasswordRequestOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ForgetPasswordRequestOn",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgetPasswordRequestOn",
                table: "Student");
        }
    }
}
