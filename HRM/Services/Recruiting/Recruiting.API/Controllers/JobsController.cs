using ApplicationCode.Contract.Services;
using ApplicationCode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        //https://localhost:5001/api/jobs
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();

            // return Json data + HTTP Status Code 200
            // serialization c# objects into json objects using System.Text.Json
            if (jobs.Any())
            {
                return Ok(jobs); // HTTP Status Code 200
            }
            else
            {
                return NotFound(new { error = "No open jobs found, please try later" }); // HTTP Status Code 404
            }
        }

        //https://localhost:5001/api/jobs/1
        [Route("{id:int}", Name = "GetJobDetails")]
        [HttpGet]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new { error = $"Job with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(job); // HTTP Status Code 200
            }
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var job = await _jobService.AddJob(model);
            return CreatedAtAction("GetJobDetails", new {controller = "Jobs", id = job}, "Job Created");

        }
    }
}
