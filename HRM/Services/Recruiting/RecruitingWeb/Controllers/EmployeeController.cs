using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
