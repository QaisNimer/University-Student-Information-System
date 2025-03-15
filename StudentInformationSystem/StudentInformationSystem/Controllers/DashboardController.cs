using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.BussinessLogic.ISevices;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ISessionManagement _session;
        public readonly IStudent _student;
        public DashboardController(IStudent student, ISessionManagement session)
        {
            _session = session;
            _student = student;
        }
        public async Task<IActionResult> Index()
        {
            long studentId = Convert.ToInt64(_session.GetSession("StudentId"));
            var student = await _student.GetByIdAsync(studentId);

            if (student != null)
            {
                HttpContext.Session.SetString("UserName", student.EnglishName);
                HttpContext.Session.SetString("UserProfileImageUrl", student.ImagePath);
            }
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            long StudentId = Convert.ToInt64(_session.GetSession("StudentId"));
            var dta=await _student.GetByIdAsync(StudentId);
            return View(dta);
        }
    }
}
