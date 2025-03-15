using AutoMapper;
using Azure.Core;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StudentInformationSystem.BussinessLogic.ISevices;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using StudentInformationSystem.Utilities.Dto;
using System.Linq;
using static SkiaSharp.HarfBuzz.SKShaper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentInformationSystem.Controllers
{
    public class CourseController : Controller
    {
        public readonly ICourse _course;
        public readonly IRegisterCourse _registerCourse;
        public readonly IDNTCaptchaValidatorService _DNTCaptchaValidator;
        public readonly DNTCaptchaOptions _dNTCaptchaOptions;
        private readonly IMapper _mapper;
        private readonly ISemester _semester;
        private readonly ISessionManagement _session;
        private readonly IMarks _marks;

        public CourseController(
            ISessionManagement session,
            IMapper mapper,
            ICourse course,
            IDNTCaptchaValidatorService DNTCaptchaValidator,
            IOptions<DNTCaptchaOptions> dNTCaptchaOptions,
            IRegisterCourse registerCourse,
            ISemester semester,
            IMarks marks
            )
        {
            _marks = marks;
            _session = session;
            _semester = semester;
            _mapper = mapper;
            _course = course;
            _registerCourse = registerCourse;
            _DNTCaptchaValidator = DNTCaptchaValidator;
            _dNTCaptchaOptions = dNTCaptchaOptions == null ? throw new ArgumentNullException(nameof(dNTCaptchaOptions)) : dNTCaptchaOptions.Value;
        }

        public async Task<IActionResult> CourseSchedule(CousreViewListDto request)
        {
           
            var query = await _course.GetAllAsync();

            if (request?.courseRequest != null)
            {
                if (!string.IsNullOrEmpty(request.courseRequest.CourseName))
                {
                    query = query.Where(x => x.CourseName == request.courseRequest.CourseName);
                }
                if (!string.IsNullOrEmpty(request.courseRequest.CourseCode))
                {
                    query = query.Where(x => x.CourseCode == request.courseRequest.CourseCode);
                }
                if (!string.IsNullOrEmpty(request.courseRequest.CourseNumber))
                {
                    query = query.Where(x => x.CourseNumber == request.courseRequest.CourseNumber);
                }
            }

            request.courses = query.OrderBy(c => c.CourseNumber).ToList();
            return View(request);
        }
        
        public async Task<IActionResult> AddCourse(int courseId)
        {
            AddCourseDto obj = new AddCourseDto();
            int StudentId = Convert.ToInt32(_session.GetSession("StudentId"));
            var courseListDto = _registerCourse.GetRegisteredCoursesByStudent(StudentId);
            ViewBag.CourseCharacterList = courseListDto.Item3;
            obj.CourseList = courseListDto.Item1;
            ViewBag.SemesterList = await _semester.ListAsync(x => x.Id == courseListDto.Item2);
            if (courseId > 0) 
            {
                var data = await _course.GetByIdAsync(Convert.ToInt64(courseId));
                if(data is not null)
                {
                    obj.RegisterCourse.CourseId = data.Id;
                    obj.RegisterCourse.CourseName = data.CourseName;
                    obj.RegisterCourse.CourseNumber = data.CourseNumber;
                    obj.RegisterCourse.CourseCharacters = data.CourseCode;
                    obj.CourseList = courseListDto.Item1;
                    return View(obj);
                }
                return View(obj);
            }
            return View(obj);
        }
        public async Task<JsonResult> GetCourseByCharacter(string Character)
        {
            var data = await _course.GetEntityWithSpec(x => x.CourseNumber == Character);
            return Json(data);
        }

        public async Task<IActionResult> GetCourseByCourseNumber(string CourseNumber)
        {
            int DepartmentId = Convert.ToInt32(_session.GetSession("DepartmentId"));
            var courses = await _course.ListAsync(x => x.DepartmentId.Equals(DepartmentId) && x.CourseNumber.Equals(CourseNumber));
            var result = courses.Select(c => new
            {
                c.Id,
                c.CourseCode,
                c.CourseNumber,
                c.CourseName,
                c.Section
            }).ToList();

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourseDto req)
        {
            AddCourseDto obj = new AddCourseDto();
            int StudentId = Convert.ToInt32(_session.GetSession("StudentId"));
            var courseListDto = _registerCourse.GetRegisteredCoursesByStudent(StudentId);
            ViewBag.CourseCharacterList = courseListDto.Item3;
            obj.CourseList = courseListDto.Item1;
            ViewBag.SemesterList = await _semester.ListAsync(x => x.Id == courseListDto.Item2);
            if (!ModelState.IsValid)
            {
                obj.RegisterCourse = req.RegisterCourse;
                return View(obj);
            }
            var data = await _course.GetEntityWithSpec(x => x.CourseNumber == req.RegisterCourse.CourseNumber);

            if (data == null)
            {
                TempData["Notification"] = "Invalid Course Number";
                obj.RegisterCourse.CourseName = req.RegisterCourse.CourseName;
                obj.RegisterCourse.CourseNumber = req.RegisterCourse.CourseNumber;
                obj.RegisterCourse.CourseCharacters = req.RegisterCourse.CourseCharacters;
                obj.CourseList = courseListDto.Item1;
                return View(obj);
            }

            if (!_DNTCaptchaValidator.HasRequestValidCaptchaEntry())
            {
                this.ModelState.AddModelError(_dNTCaptchaOptions.CaptchaComponent.CaptchaInputName, "Please Insert Valid Captcha");
            }
            else
            {
                int CountCourses = obj.CourseList.Where(x => x.CourseNumber.Equals(req.RegisterCourse.CourseNumber)).Count();
                if (CountCourses > 0)
                {
                    TempData["Notification"] = "Course Already Registered";
                }
                else
                {
                    int totalRegisteredCreditHours = obj.CourseList.Sum(x => x.Credit);
                    int maxCreditHours;
                    if (req.RegisterCourse.SemesterId == 1)
                    {
                        maxCreditHours = 18;
                    }
                    else if (req.RegisterCourse.SemesterId == 2)
                    {
                        maxCreditHours = 36;
                    }
                    else if (req.RegisterCourse.SemesterId == 3)
                    {
                        maxCreditHours = 54;
                    }
                    else
                    {
                        maxCreditHours = int.MaxValue;
                    }
                    if (req.RegisterCourse.SemesterId == 3)
                    {
                        if (totalRegisteredCreditHours + data.Credits > /*maxCreditHours*/ 12)
                        {
                            TempData["Notification"] = "You cannot register for more than the allowed credit hours for this semester.";
                        }
                        else
                        {
                            RegisteredCourses registeredCourses = new RegisteredCourses()
                            {
                                CourseId = data.Id,
                                SemesterId = req.RegisterCourse.SemesterId,
                                StudentId = Convert.ToInt32(_session.GetSession("StudentId"))
                            };
                            _registerCourse.Add(registeredCourses);
                            _registerCourse.Complete();
                            TempData["Notification"] = "Successfully Registered Course";
                        }
                    }
                    else
                    {
                        if (totalRegisteredCreditHours + data.Credits > /*maxCreditHours*/ 18)
                        {
                            TempData["Notification"] = "You cannot register for more than the allowed credit hours for this semester.";
                        }
                        else
                        {
                            RegisteredCourses registeredCourses = new RegisteredCourses()
                            {
                                CourseId = data.Id,
                                SemesterId = req.RegisterCourse.SemesterId,
                                StudentId = Convert.ToInt32(_session.GetSession("StudentId"))
                            };
                            _registerCourse.Add(registeredCourses);
                            _registerCourse.Complete();
                            TempData["Notification"] = "Successfully Registered Course";
                        }
                    }
                }
            }

            obj.RegisterCourse.CourseId = data.Id;
            obj.RegisterCourse.CourseName = req.RegisterCourse.CourseName;
            obj.RegisterCourse.CourseNumber = req.RegisterCourse.CourseNumber;
            obj.RegisterCourse.CourseCharacters = req.RegisterCourse.CourseCharacters;
            obj.CourseList = _registerCourse.GetRegisteredCoursesByStudent(StudentId).Item1;
            return View(obj);
        }

        public async Task<IActionResult> SemesterDetail()
        {
            ViewBag.SemesterList = await _semester.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SemesterDetail(int SemesterId)
        {
            CourseMarksDto obj = new();
            ViewBag.SemesterList = await _semester.GetAllAsync();
            if (!_DNTCaptchaValidator.HasRequestValidCaptchaEntry())
            {
                this.ModelState.AddModelError(_dNTCaptchaOptions.CaptchaComponent.CaptchaInputName, "Please Insert Valid Captcha");
            }
            else
            {
                int StudentId = Convert.ToInt32(_session.GetSession("StudentId"));
                obj.MarksDto = _marks.GetMarksBySemester(SemesterId, StudentId);
               
            }
            return View(obj);
        }

        public IActionResult GPACalculator()
        {

            return View();
        }

        public async Task<IActionResult> DropCourse(int courseId)
        {
            int StudentId = Convert.ToInt32(_session.GetSession("StudentId"));
            var deletionResult = await _registerCourse.DeleteAsync(x => x.CourseId == courseId && x.StudentId == StudentId);
            if (deletionResult > 0)
            {
                TempData["Notification"] = "Course dropped successfully.";
            }
            else
            {
                TempData["Notification"] = "Failed to drop course.";
            }
            return RedirectToAction("AddCourse");
        }

    }
}
