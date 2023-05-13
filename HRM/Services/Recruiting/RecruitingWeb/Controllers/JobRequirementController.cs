using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobRequirementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
