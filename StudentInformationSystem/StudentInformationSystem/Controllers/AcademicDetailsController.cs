using AutoMapper;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentInformationSystem.BussinessLogic.ISevices;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Controllers
{
    public class AcademicDetailsController : Controller
    {
        private readonly ISessionManagement _session;
        private readonly IMarks _marks;
        public AcademicDetailsController(ISessionManagement session,
            IMarks marks
            )
        {
            _marks = marks;
            _session = session;
        }

        public async Task<IActionResult> Index()
        {
            long studentId = Convert.ToInt64(_session.GetSession("StudentId"));
            var Result = await _marks.GetAcademicDetail(studentId);
            return View(Result);
        }
    }
}
