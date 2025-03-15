using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.Controllers
{
    public class Applications : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
