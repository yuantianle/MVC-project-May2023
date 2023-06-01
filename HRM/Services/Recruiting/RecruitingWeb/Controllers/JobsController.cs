using Infrastructure.Services;
using ApplicationCode;
using Microsoft.AspNetCore.Mvc;
using ApplicationCode.Contract.Services;
using ApplicationCode.Models;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private IJobService _jobService; //box factory pattern - this is the interface
        public JobsController(IJobService jobService)
        {
            _jobService = jobService; // this is the implementation
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // return all the jobs so that candidates can apply to the job
            
            //When you type "localhost:5100/Jobs/Index", it automatically run:
            //var jobsController = new JobsController(new JobService());
            //jobsController.Index();

            //ViewBag
            ViewBag.PageTitle = "All Jobs";

            var jobs = await _jobService.GetAllJobs();
            return View(jobs); //strong type view
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // get the job details by ID
            var job = await _jobService.GetJobById(id);
            return View();
        }

        // show the empty page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // save the job information to the server
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            //check if the model is valid on the server side
            if (ModelState.IsValid)
            {
                // save the job to the database
                await _jobService.AddJob(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
