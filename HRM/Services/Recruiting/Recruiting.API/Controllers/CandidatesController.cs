using ApplicationCode.Contract.Services;
using ApplicationCode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        //https://localhost:5001/api/candidates
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            if (candidates.Any())
            {
                return Ok(candidates); // HTTP Status Code 200
            }
            else
            {
                return NotFound(new { error = "No candidates found" }); // HTTP Status Code 404
            }
        }


        //https://localhost:5001/api/candidates/1
        [Route("{id:int}", Name = "GetCandidateDetails")]
        [HttpGet]   
        public async Task<IActionResult> GetCandidateDetails(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound(new { error = $"Candidate with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(candidate); // HTTP Status Code 200
            }
        }

        //update resume
        //https://localhost:5001/api/candidates/1
        [Route("{id:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCandidateResume(int id, string newResumeURL)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var candidate = await _candidateService.UpdateCandidateResume(id, newResumeURL);
            if (candidate == null)
            {
                return NotFound(new { error = $"Candidate with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(candidate); // HTTP Status Code 200
            }
        }   
        
        //https://localhost:5001/api/candidates/create/1
        [Route("create/{jobid:int}")]
        [HttpPost]
        public async Task<IActionResult> Create(CandidateRequestModel model, int jobid)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var candidate = await _candidateService.AddCandidate(model, jobid);
            return CreatedAtAction("GetCandidateDetails", new { controller = "Candidates", id = candidate }, "Candidate Created");
        }
    }
}
