using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Short = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSaturday = table.Column<bool>(type: "bit", nullable: false),
                    IsSunday = table.Column<bool>(type: "bit", nullable: false),
                    IsMonday = table.Column<bool>(type: "bit", nullable: false),
                    IsTuesday = table.Column<bool>(type: "bit", nullable: false),
                    IsWednesday = table.Column<bool>(type: "bit", nullable: false),
                    IsThursday = table.Column<bool>(type: "bit", nullable: false),
                    TreacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSeat = table.Column<int>(type: "int", nullable: false),
                    HallNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseNature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specilization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUbSpecilty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CumulativeAverage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaduateStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "DepartmentName", "Short" },
                values: new object[,]
                {
                    { 1L, "Computer engineering", "CPE" },
                    { 2L, "Electronics engineering", "ELE" },
                    { 3L, "Communications engineering", "CME" },
                    { 4L, "Civil engineering", "CEF" },
                    { 5L, "Biomedical engineering", "BME" },
                    { 6L, "Industrial engineering", "IEU" },
                    { 7L, "Electrical power engineering", "EPE" },
                    { 8L, "Marketing", "MKT" },
                    { 9L, "Law", "L" },
                    { 10L, "Economy", "ECON" },
                    { 11L, "Chemistry", "CHEM" },
                    { 12L, "Physics", "PHYS" },
                    { 13L, "Computer Science", "CS" },
                    { 14L, "Statistics", "STAT" },
                    { 15L, "mathematics", "MATH" },
                    { 16L, "English Language and its literature", "EL" },
                    { 17L, "Arabic language and its literature", "AL" },
                    { 18L, "Accounting", "ACC" },
                    { 19L, "Business Management", "BA" },
                    { 20L, "General Administration", "PA" },
                    { 21L, "Optional 1", "HUM" },
                    { 22L, "Optional 2", "Sci" },
                    { 23L, "Doctor of Medicine", "M" },
                    { 24L, "Pharmacy", "M" },
                    { 25L, "Architecture engineering", "AE" },
                    { 26L, "Mechanical engineering technology and design", "ME" },
                    { 27L, "Computer information systems", "CIS" },
                    { 28L, "Business information technology", "SCI" },
                    { 29L, "Cyber security", "CYS" },
                    { 30L, "Data science and artificial intelligence", "DA" },
                    { 31L, "Medical and biophysics", "MPHY" },
                    { 32L, "Biology", "BIO" },
                    { 33L, "Earth and Environmental Sciences", "AG" },
                    { 34L, "Economics of finance and business", "BF" },
                    { 35L, "French language", "FREN" },
                    { 36L, "Translation", "TRA" },
                    { 37L, "Hebrew", "HEB" },
                    { 38L, "Turkish language", "TUR" },
                    { 39L, "History", "HIST" },
                    { 40L, "Geography", "GEO" },
                    { 41L, "Political Science", "PS" },
                    { 42L, "Sociology and Social Work", "SOC" },
                    { 43L, "Class teacher", "CURI" },
                    { 44L, "psychological guidance", "PSYC" },
                    { 45L, "Raising a child", "EDAF" },
                    { 46L, "Jurisprudence and its principles", "FQH" },
                    { 47L, "Religion basics", "ASL" },
                    { 48L, "Islamic studies", "ISS" },
                    { 49L, "Economics and Islamic banking", "IEB" },
                    { 50L, "Archaeology", "ARCH" },
                    { 51L, "Anthropologist", "ANTH" },
                    { 52L, "Maintenance of heritage resources and management", "CON" },
                    { 53L, "Tourism management", "TOUR" },
                    { 54L, "Tourist guides", "TOUR" },
                    { 55L, "Hotel management", "HOTL" },
                    { 56L, "Public relations and advertising", "PRA" },
                    { 57L, "Journalism", "JRN" },
                    { 58L, "Radio and television", "RTV" },
                    { 59L, "physical education", "PE" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "AvailableSeat", "CourseCode", "CourseName", "CourseNature", "CourseNumber", "Credits", "DepartmentId", "HallNumber", "IsMonday", "IsSaturday", "IsSunday", "IsThursday", "IsTuesday", "IsWednesday", "Note", "Section", "TimeForm", "TimeTo", "TreacherName" },
                values: new object[,]
                {
                    { 1L, 70, null, "AI", "Onsite", "576", 3, 1L, "101", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Yazan Al Issa" },
                    { 2L, 69, null, "C++", "Onsite", "150", 3, 1L, "103", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Manal Al Bazour" },
                    { 3L, 90, null, "C++ Lab", "Onsite", "150L", 1, 1L, "420", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Manal Al Bazour" },
                    { 4L, 70, null, "Software", "Onsite", "452", 3, 1L, "421", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Yazan Al Issa" },
                    { 5L, 70, null, "Software Lab", "Onsite", "453", 1, 1L, "422", false, false, true, true, true, false, null, "5", "45413.5", "45473.541666666664", "Yazan Al Issa" },
                    { 6L, 80, null, "C#", "Onsite", "360", 3, 1L, "423", true, true, false, false, false, true, null, "6", "45413.375", "45473.416666666664", "Muhammad Al Jarrah" },
                    { 7L, 90, null, "C# Lab", "Onsite", "360L", 1, 1L, "425", true, true, false, false, false, true, null, "7", "45413.416666666664", "45473.458333333336", "Muhammad Al Jarrah" },
                    { 8L, 70, null, "Database", "Onsite", "450", 3, 1L, "520", true, true, false, false, false, true, null, "8", "45413.5", "45473.541666666664", "Safaa Batayneh" },
                    { 9L, 80, null, "Database Lab", "Onsite", "450L", 1, 1L, "521", true, true, false, false, false, true, null, "9", "45413.541666666664", "45473.583333333336", "Safaa Batayneh" },
                    { 10L, 70, null, "SP", "Onsite", "466", 3, 1L, "127", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Hisham Al-Masaieed" },
                    { 11L, 90, null, "SP Lab", "Onsite", "466L", 1, 1L, "128", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Hisham Al-Masaieed" },
                    { 12L, 80, null, "Numerical", "Onsite", "310", 3, 1L, "132", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Ola Taani" },
                    { 13L, 70, null, "Data Structure", "Onsite", "354", 3, 1L, "131", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Hisham Al-Masaieed" },
                    { 14L, 80, null, "Data Structure Lab", "Onsite", "354L", 1, 1L, "130", false, false, true, true, true, false, null, "5", "45413.5", "45473.541666666664", "Hisham Al-Masaieed" },
                    { 15L, 90, null, "OS", "Onsite", "460", 3, 1L, "227", true, true, false, false, false, true, null, "6", "45413.375", "45473.416666666664", "Hisham Al-Masaieed" },
                    { 16L, 90, null, "OS Lab", "Onsite", "460L", 1, 1L, "425", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Hisham Al-Masaieed" },
                    { 17L, 90, null, "Digital", "Onsite", "230", 3, 1L, "420", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Sami Al Hamdan" },
                    { 18L, 70, null, "Digital Lab", "Onsite", "231", 1, 1L, "421", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Sami Al Hamdan" },
                    { 19L, 90, null, "Micro", "Onsite", "344", 3, 1L, "232", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Maher Al Omari" },
                    { 20L, 80, null, "Orga", "Onsite", "320", 3, 1L, "230", false, false, true, true, true, false, null, "5", "45413.5", "45473.541666666664", "Mahmoud Masadeh" },
                    { 21L, 80, null, "Archi", "Onsite", "440", 3, 1L, "231", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Haitham Al Mufleh" },
                    { 22L, 90, null, "Orga Lab", "Onsite", "441", 1, 1L, "232", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Mahmoud Masadeh" },
                    { 23L, 80, null, "Micro Lab", "Onsite", "345", 1, 1L, "327", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Maher Al Omari" },
                    { 24L, 80, null, "Embeded", "Onsite", "542", 3, 1L, "221", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Safaa Batayneh" },
                    { 25L, 90, null, "Embeded Lab", "Onsite", "543", 1, 1L, "222", false, false, true, true, true, false, null, "5", "45413.5", "45473.541666666664", "Safaa Batayneh" },
                    { 26L, 80, null, "Signal", "Onsite", "312", 3, 1L, "223", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Rami Halloush" },
                    { 27L, 80, null, "Network", "Onsite", "562", 3, 1L, "224", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Muhammad Haloush" },
                    { 28L, 90, null, "Network Lab", "Onsite", "563", 1, 1L, "225", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Muhammad Haloush" },
                    { 29L, 80, null, "Security", "Onsite", "578", 3, 1L, "320", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Haitham Al Mufleh" },
                    { 30L, 90, null, "Image Processing", "Onsite", "584", 3, 1L, "321", false, false, true, true, true, false, null, "5", "45413.5", "45473.541666666664", "Farouk Al Omari" },
                    { 31L, 90, null, "Electronics 1", "Onsite", "250", 3, 2L, "227", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Yusra Obaidat" },
                    { 32L, 80, null, "Electronics Lab", "Onsite", "251", 1, 2L, "228", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Yusra Obaidat" },
                    { 33L, 90, null, "DE", "Onsite", "450", 3, 2L, "229", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Idris Al Kofahi" },
                    { 34L, 50, null, "Diff2", "Onsite", "216", 3, 3L, "505", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Khaled Gharaibeh" },
                    { 35L, 79, null, "System", "Onsite", "456", 3, 3L, "507", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Muhammad Al Rawashdeh" },
                    { 36L, 61, null, "Data Com", "Onsite", "463", 3, 3L, "509", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Hazem Al Shakhatra" },
                    { 37L, 59, null, "Prob", "Onsite", "314", 3, 3L, "512", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Hassan Al Thiabat" },
                    { 38L, 69, null, "Circuit 1", "Onsite", "220", 3, 7L, "203", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Maha Zaqout" },
                    { 39L, 60, null, "Circuit 2", "Onsite", "222", 3, 7L, "209", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Abed Al Ghany Athamneh" },
                    { 40L, 75, null, "Circuit Lab", "Onsite", "223", 1, 7L, "212", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Abed Al Ghany Athamneh" },
                    { 41L, 120, null, "General Chemistry", "Onsite", "101E", 3, 11L, "105", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Areej Al-Ghoul" },
                    { 42L, 180, null, "General Chemistry Lab", "Online", "105", 1, 11L, "104", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Areej Al-Ghoul" },
                    { 43L, 140, null, "Calculus 1", "Onsite", "101", 3, 15L, "206", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Muhammad Khair Al Jarrarhah" },
                    { 44L, 160, null, "Calculus 2", "Onsite", "102", 3, 15L, "207", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Muhammad Batayneh" },
                    { 45L, 180, null, "Diff 1", "Onsite", "205", 3, 15L, "208", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Mahdi Lataifa" },
                    { 46L, 140, null, "Discrete", "Onsite", "152", 3, 15L, "210", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Jenan Shtaiyat" },
                    { 47L, 60, null, "Physics 1", "Onsite", "101", 3, 12L, "104", false, false, true, true, true, false, null, "1", "45413.333333333336", "45473.375", "Nihad TashTimeToush" },
                    { 48L, 70, null, "Physics 2", "Onsite", "102", 3, 12L, "105", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Manal Abdullah" },
                    { 49L, 65, null, "Physics 1 Lab", "Onsite", "105", 1, 12L, "106", false, false, true, true, true, false, null, "3", "45413.416666666664", "45473.458333333336", "Nihad TashTimeToush" },
                    { 50L, 60, null, "Physics 2 Lab", "Onsite", "106", 1, 12L, "107", false, false, true, true, true, false, null, "4", "45413.458333333336", "45473.5", "Manal Abdullah" },
                    { 51L, 90, null, "Introduction TimeTo Engineering", "Onsite", "152", 2, 5L, "232", false, false, true, true, true, false, null, "2", "45413.375", "45473.416666666664", "Muhammad Al Rawashdeh" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AcademicStatus", "ArabicName", "BirthDate", "CollegeID", "CollegeName", "CumulativeAverage", "DepartmentId", "Email", "EnglishName", "GaduateStatus", "Gender", "ImagePath", "Nationality", "Password", "PlaceOfBirth", "SUbSpecilty", "Specilization", "UserName" },
                values: new object[,]
                {
                    { 1L, "He studies", "زيد رياض حداد", "13-07-2001", "2019980085", "Al-Hijjawi for Technological Engineering", null, 1L, "zaidreyadhaddad@gmail.com", "zaid reyad haddad", "No", "male", "ImagePath", "jordan", "Zaidreyadhaddad1@", "irbid", null, null, "Zaidreyadhaddad" },
                    { 2L, "He studies", "قيس ايهاب نمر", "13-07-2001", "2019980118", "Al-Hijjawi for Technological Engineering", null, 1L, "QaisIhabNimer@gmail.com", "Qais Ihab Nimer", "No", "male", "ImagePath", "jordan", "QaisIhabNimer1@", "amman", null, null, "QaisIhabNimer" },
                    { 3L, "She studies", "براء هاني مقطش", "13-07-2001", "2019980043", "Al-Hijjawi for Technological Engineering", null, 1L, "BaraHaniMukattash@gmail.com", "Bara’ Hani Mukattash", "No", "female", "ImagePath", "jordan", "BaraHaniMukattash1@", "ajloun", null, null, "BaraHaniMukattash" },
                    { 4L, "She studies", "زينة جمال عبيدات", "13-07-2001", "209980086", "Al-Hijjawi for Technological Engineering", null, 1L, "ZainaJamalObaidat@gmail.com", "Zaina Jamal Obaidat", "No", "female", "ImagePath", "jordan", "ZainaJamalObaidat1@", "irbid", null, null, "ZainaJamalObaidat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
