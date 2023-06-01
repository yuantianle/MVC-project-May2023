using ApplicationCode.Contract.Repositories;
using ApplicationCode.Contract.Services;
using ApplicationCode.Entities;
using ApplicationCode.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        //get all candidates
        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidates()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            var response = new List<CandidateResponseModel>();
            foreach (var candidate in candidates)
            {
                response.Add(new CandidateResponseModel
                {
                    Id = candidate.Id,
                    CreateOn = candidate.CreateOn,
                    Email = candidate.Email,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    MiddleName = candidate.MiddleName,
                    ResumeURL = candidate.ResumeURL
                });
            }
            return response;
        }
        public async Task<CandidateResponseModel> GetCandidateById(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null) return null;
            var response = new CandidateResponseModel
            {
                Id = candidate.Id,
                CreateOn = candidate.CreateOn,
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                MiddleName = candidate.MiddleName,
                ResumeURL = candidate.ResumeURL
            };
            return response;
        }
        public async Task<int> AddCandidate(CandidateRequestModel model, int jobid)
        {
            var CandicateEntity = new Candidate
            {
                CreateOn = DateTime.UtcNow,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                ResumeURL = model.ResumeURL
            };
            
            var candidate = await _candidateRepository.AddAsync(CandicateEntity);
            //add the candidate into submission table
            var submission = new Submission
            {
                CandidateId = candidate.Id,
                JobId = jobid,
                SubmittedOn = DateTime.UtcNow
            };
            await _candidateRepository.AddSubmission(candidate.Id, submission);
            return candidate.Id;
        }

        public async Task<CandidateResponseModel> UpdateCandidateResume(int id, string newResumeURL)
        {
            var candidate = await _candidateRepository.UpdateResume(id, newResumeURL);
            if (candidate == null) return null;
            var response = new CandidateResponseModel
            {
                Id = candidate.Id,
                CreateOn = candidate.CreateOn,
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                MiddleName = candidate.MiddleName,
                ResumeURL = candidate.ResumeURL
            };
            return response;
        }
    }
}
