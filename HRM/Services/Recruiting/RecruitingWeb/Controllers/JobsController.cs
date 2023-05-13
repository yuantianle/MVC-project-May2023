using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // return all the jobs so that candidates can apply to the job
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
