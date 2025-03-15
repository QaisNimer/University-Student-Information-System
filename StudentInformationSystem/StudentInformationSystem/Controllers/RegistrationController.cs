using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
