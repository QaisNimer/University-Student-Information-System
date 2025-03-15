using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Utilities.CommonMethod;
using static StudentInformationSystem.Utilities.Constrant.Constant;

namespace StudentInformationSystem.Infrastructure.Database
{
    public class DatabaseInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public DatabaseInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void DataBaseSeed()
        {
            string DepartmentFileLocation = Environment.CurrentDirectory + SeedingFileNameConstants.DepartmentJson;
            var DepartmentData = CommonMethod.GetFile(DepartmentFileLocation);
            string DepartmentSerializestring = JsonConvert.SerializeObject(DepartmentData.DepartmentList);
            List<Department> DepartmentList = JsonConvert.DeserializeObject<List<Department>>(DepartmentSerializestring);
            this.modelBuilder.Entity<Department>().HasData(DepartmentList);


            string CourseFileLocation = Environment.CurrentDirectory + SeedingFileNameConstants.CourseJson;
            var CourseData = CommonMethod.GetFile(CourseFileLocation);
            string CourseSerializestring = JsonConvert.SerializeObject(CourseData.CourseList);
            List<Course> CityList = JsonConvert.DeserializeObject<List<Course>>(CourseSerializestring);
            this.modelBuilder.Entity<Course>().HasData(CityList);

            string StudentFileLocation = Environment.CurrentDirectory + SeedingFileNameConstants.StudentJson;
            var StudentData = CommonMethod.GetFile(StudentFileLocation);
            string StudentSerializestring = JsonConvert.SerializeObject(StudentData.StudentList);
            List<Student> StudentList = JsonConvert.DeserializeObject<List<Student>>(StudentSerializestring);
            this.modelBuilder.Entity<Student>().HasData(StudentList);

            string SemesterFileLocation = Environment.CurrentDirectory + SeedingFileNameConstants.SemesterJson;
            var SemesterData = CommonMethod.GetFile(SemesterFileLocation);
            string SemesterSerializestring = JsonConvert.SerializeObject(SemesterData.SemesterList);
            List<Semester> SemesterList = JsonConvert.DeserializeObject<List<Semester>>(SemesterSerializestring);
            this.modelBuilder.Entity<Semester>().HasData(SemesterList);

            string StudyPlanFileLocation = Environment.CurrentDirectory + SeedingFileNameConstants.StudyPlanJson;
            var StudyPlanData = CommonMethod.GetFile(StudyPlanFileLocation);
            string StudyPlanSerializestring = JsonConvert.SerializeObject(StudyPlanData.StudyPlanList);
            List<StudyPlan> StudyPlanList = JsonConvert.DeserializeObject<List<StudyPlan>>(StudyPlanSerializestring);
            this.modelBuilder.Entity<StudyPlan>().HasData(StudyPlanList);

            //string MarksFileLocation = Environment.CurrentDirectory + SeedingFileNameConstants.MarksJson;
            //var MarksData = CommonMethod.GetFile(MarksFileLocation);
            //string MarksSerializestring = JsonConvert.SerializeObject(MarksData.MarksList);
            //List<Marks> MarksList = JsonConvert.DeserializeObject<List<Marks>>(MarksSerializestring);
            //this.modelBuilder.Entity<Marks>().HasData(MarksList);

        }
    }
}
