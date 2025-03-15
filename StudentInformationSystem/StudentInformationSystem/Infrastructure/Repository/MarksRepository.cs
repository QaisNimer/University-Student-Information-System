using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using StudentInformationSystem.Utilities.Dto;
using System.ComponentModel;
using System.Data;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class MarksRepository : GenericRepository<Marks>, IMarks
    {
        private readonly ApplicationContext _Context;
        private readonly ISqlTransactionQuery _sqlTransactionQuery;

        public MarksRepository(ApplicationContext Context, ISqlTransactionQuery sqlTransactionQuery) : base(Context)
        {
            _Context = Context;
            _sqlTransactionQuery = sqlTransactionQuery;
        }

        public dynamic GetMarksBySemester(int SemesterId, int StudentId) 
        {
            try
            {
                var Result = (from m in _Context.Marks
                              join rc in _Context.RegisteredCourses on m.RegisteredCourseId equals rc.Id
                              join c in _Context.Courses on rc.CourseId equals c.Id
                              where rc.StudentId.Equals(StudentId) && rc.SemesterId.Equals(SemesterId)
                              select new MarksDto
                              {
                                  CourseCharacters = c.CourseCode,
                                  CourseName = c.CourseName,
                                  CourseNumber = c.CourseNumber,
                                  Hours = c.Credits,
                                  Section = c.Section,
                                  WorkMarks = m.FirstMarks,
                                  MidTermMarks = m.SecondMarks,
                                  CollectionMarks = m.FinalMarks
                              }).ToList();
                return Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<AcademicDetailsDto> GetAcademicDetail(long StudentId)
        {
            try
            {
                AcademicDetailsDto result = new();
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>
                {
                    { "@StudentId", StudentId }
                };

                // Execute stored procedure
                var data = await _sqlTransactionQuery.ExecuteSp("GetAcademicDetail", param);

                if (data?.Tables.Count > 0)
                {
                    // Map CourseAcademicDetails
                    result.CourseAcademicDetailsDto = (from DataRow row in data.Tables[0].Rows
                                                       select new CourseAcademicDetailsDto
                                                       {
                                                           CourseCharacters = row["CourseCharacters"]?.ToString(),
                                                           CourseName = row["CourseName"]?.ToString(),
                                                           CourseNumber = row["CourseNumber"]?.ToString(),
                                                           NumberOfHours = row["NumberOfHours"] != DBNull.Value ? Convert.ToInt32(row["NumberOfHours"]) : 0,
                                                           Marks = row["Marks"] != DBNull.Value ? Convert.ToInt32(row["Marks"]) : 0,
                                                           MarksStatus = row["MarksStatus"]?.ToString(),
                                                           Semester = row["Semester"] != DBNull.Value ? Convert.ToInt32(row["Semester"]) : 0,
                                                           Year = row["Year"]?.ToString()
                                                       }).ToList();

                    // Map SummaryAcademicDetails
                    result.SummaryAcademicDetailDto = (from DataRow row in data.Tables[1].Rows
                                                       select new SummaryAcademicDetailDto
                                                       {
                                                           Semester = row["Semester"] != DBNull.Value ? Convert.ToInt32(row["Semester"]) : 0,
                                                           Year = row["Year"]?.ToString(),
                                                           SemesterGPA = row["SemesterGPA"] != DBNull.Value ? Convert.ToInt32(row["SemesterGPA"]) : 0,
                                                           NumberOfSemesterHours = row["NumberOfSemesterHours"] != DBNull.Value ? Convert.ToInt32(row["NumberOfSemesterHours"]) : 0,
                                                           TotalHoursStuiedByStudent = row["TotalHoursStudiedByStudent"] != DBNull.Value ? Convert.ToInt32(row["TotalHoursStudiedByStudent"]) : 0,
                                                           CumulativeGPA = row["CumulativeGPA"] != DBNull.Value ? Convert.ToInt32(row["CumulativeGPA"]) : 0
                                                       }).ToList();

                    // Map cumulative statistics
                    var cumulativeStats = data.Tables[2].Rows[0];
                    result.TotalCumulativeHours = cumulativeStats["TotalCumulativeHours"] != DBNull.Value ? Convert.ToInt32(cumulativeStats["TotalCumulativeHours"]) : 0;
                    result.CumulativeAverage = cumulativeStats["CumulativeAverage"] != DBNull.Value ? Convert.ToInt32(cumulativeStats["CumulativeAverage"]) : 0;
                    result.TotalCumulativeMarks = cumulativeStats["TotalCumulativeMarks"] != DBNull.Value ? Convert.ToInt32(cumulativeStats["TotalCumulativeMarks"]) : 0;
                    result.TotalNumberOfHoursPassedByTheStudent = cumulativeStats["TotalNumberOfHoursPassedByTheStudent"] != DBNull.Value ? Convert.ToInt32(cumulativeStats["TotalNumberOfHoursPassedByTheStudent"]) : 0;
                }


                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching academic details.", ex);
            }
        }
    }
}
