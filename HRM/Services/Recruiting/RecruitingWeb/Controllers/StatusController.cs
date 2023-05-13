using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
