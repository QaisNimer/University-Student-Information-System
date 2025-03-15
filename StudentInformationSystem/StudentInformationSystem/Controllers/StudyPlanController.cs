using AutoMapper;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentInformationSystem.BussinessLogic.ISevices;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using StudentInformationSystem.Utilities.Dto;

namespace StudentInformationSystem.Controllers
{
    public class StudyPlanController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudyPlan _studyPlan; 
        private readonly ICourse _course;
        private readonly ISessionManagement _sessionManagement;
        private readonly IRegisterCourse _registerCourse;

        public StudyPlanController(
            ICourse course,
            IMapper mapper,
            IStudyPlan studyPlan,
            ISessionManagement sessionManagement,
            IRegisterCourse registerCourse)
        {
            _course = course;
            _studyPlan = studyPlan;
            _mapper = mapper;
            _sessionManagement = sessionManagement;
            _registerCourse = registerCourse;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Notification = TempData["Notification"] as string;
            var Result = new StudyPlanCoursesListDto();
            var allCourses = await _course.GetAllAsync();
            int StudentId = Convert.ToInt32(_sessionManagement.GetSession("StudentId"));
            int DepartmentId = Convert.ToInt32(_sessionManagement.GetSession("DepartmentId"));
            var studentEnrolledCourses = await _registerCourse.ListAsync(x => x.StudentId.Equals(StudentId));

            var groupedCourses = allCourses.Where(x => x.DepartmentId.Equals(DepartmentId)).GroupBy(x => x.StudyPlanId)
                                           .ToDictionary(
                                               group => group.Key,
                                               group => group.Select(c => new StudyPlanCoursesDto
                                               {
                                                   Id = c.Id,
                                                   CourseCode = c.CourseCode,
                                                   CourseNumber = c.CourseNumber,
                                                   CourseName = c.CourseName,
                                                   Credits = c.Credits,
                                                   HeStudyIt = studentEnrolledCourses.Any(ec => ec.CourseId == c.Id) ? "Yes" : "No"
                                               }).OrderBy(c => c.CourseNumber).ToList());

            // Assign courses to each category in Result directly from groupedCourses
            Result.CompulsoryUniversity = groupedCourses.GetValueOrDefault(1);
            Result.CompulsorySection = groupedCourses.GetValueOrDefault(2);
            Result.OptionalUniversity = groupedCourses.GetValueOrDefault(3);
            Result.CompulsoryCollege = groupedCourses.GetValueOrDefault(4);
            Result.ElectiveDepartment = groupedCourses.GetValueOrDefault(5);

            // Calculate sum of credit hours for each category
            Result.CompulsoryUniversityTotalCredits = (Result.CompulsoryUniversity ?? new List<StudyPlanCoursesDto>()).Sum(c => c.Credits);
            Result.CompulsorySectionTotalCredits = (Result.CompulsorySection ?? new List<StudyPlanCoursesDto>()).Sum(c => c.Credits);
            Result.OptionalUniversityTotalCredits = (Result.OptionalUniversity ?? new List<StudyPlanCoursesDto>()).Sum(c => c.Credits);
            Result.CompulsoryCollegeTotalCredits = (Result.CompulsoryCollege ?? new List<StudyPlanCoursesDto>()).Sum(c => c.Credits);
            Result.ElectiveDepartmentTotalCredits = (Result.ElectiveDepartment ?? new List<StudyPlanCoursesDto>()).Sum(c => c.Credits);
            return View(Result);
        }

        public async Task<IActionResult> CheckCourse(int courseId)
        {
            //var courseId = Request.Query["courseId"].ToString();
            int StudentId = Convert.ToInt32(_sessionManagement.GetSession("StudentId"));
            var Course = await _registerCourse.GetEntityWithSpec(x => x.CourseId == Convert.ToInt32(courseId) && x.StudentId == StudentId);
            if (Course is null)
            {
                return RedirectToAction("AddCourse", "Course", new { Id = courseId });
            }
            TempData["Notification"] = "Already Enroll";
            return RedirectToAction("Index", "StudyPlan");
        }
    }
}
