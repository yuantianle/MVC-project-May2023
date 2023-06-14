using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        public InterviewsController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }
        //https://localhost:5001/api/interviews
        [Route("")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllInterviews()
        {
            var interviews = await _interviewService.GetAllInterviews();
            // return Json data + HTTP Status Code 200
            // serialization c# objects into json objects using System.Text.Json
            if (interviews.Any())
            {
                return Ok(interviews); // HTTP Status Code 200
            }
            else
            {
                return NotFound(new { error = "No Interview found, please try later" }); // HTTP Status Code 404
            }
        }
        //https://localhost:5001/api/interviews/1
        [Route("{id:int}", Name = "GetInterviewDetails")]
        [HttpGet]
        public async Task<IActionResult> GetInterviewDetails(int id)
        {
            var interview = await _interviewService.GetInterviewById(id);
            if (interview == null)
            {
                return NotFound(new { error = $"Interview with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(interview); // HTTP Status Code 200
            }
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var interview = await _interviewService.AddInterview(model);
            return CreatedAtAction("GetInterviewDetails", new { controller = "Interviews", id = interview }, "Interview Created");
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var interview = await _interviewService.DeleteInterview(id);
            if (interview == null)
            {
                return NotFound(new { error = $"Interview with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(interview); // HTTP Status Code 200
            }
        }


        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, InterviewRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var interview = await _interviewService.UpdateInterview(id, model);
            if (interview == null)
            {
                return NotFound(new { error = $"Interview with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(interview); // HTTP Status Code 200
            }
        }
    }
}
