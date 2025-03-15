namespace StudentInformationSystem.Utilities.Constrant
{
    public class Constant
    {
        public const string EmailTemplates = "EmailTemplates";

        public struct SeedingFileNameConstants
        {
            public const string DepartmentJson = "\\wwwroot\\JsonFile\\DepartmentJson.json";
            public const string CourseJson = "\\wwwroot\\JsonFile\\CourseJson.json";
            public const string StudentJson = "\\wwwroot\\JsonFile\\Student.json";
            public const string SemesterJson = "\\wwwroot\\JsonFile\\Semester.json";
            public const string StudyPlanJson = "\\wwwroot\\JsonFile\\StudyPlan.json";
            public const string MarksJson = "\\wwwroot\\JsonFile\\Marks.json";
        }

        public struct EmailTemplate
        {
            public const string ForgotPasswordEmail = "forgot-password-template.html";
        }
    }
}
