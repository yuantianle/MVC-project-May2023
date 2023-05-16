using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Contract;

namespace Infrastructure.Servieces
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _interviewRepository; //dependency injection
        public InterviewService(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }

        public async Task<List<InterviewResponseModel>> GetAllInterviews()
        {
            var interviews = await _interviewRepository.GetAllInterviews();
            var interviewResponseModels = new List<InterviewResponseModel>();
            foreach (var interview in interviews)
            {
                var interviewResponseModel = new InterviewResponseModel
                {
                    Id = interview.Id,
                    BeginTime = interview.BeginTime,
                    CandidateEmail = interview.CandidateEmail,
                    CandidateFirstName = interview.CandidateFirstName,
                    CandidateIdentityId = interview.CandidateIdentityId,
                    CandidateLastName = interview.CandidateLastName,
                    EndTime = interview.EndTime,
                    Feedback = interview.Feedback,
                    Passed = interview.Passed,
                    Rating = interview.Rating,
                    SubmissionId = interview.SubmissionId,
                    InterviewerId = interview.InterviewerId,
                    InterviewTypeId = interview.InterviewTypeId,
                };
                interviewResponseModels.Add(interviewResponseModel);
            }
            return interviewResponseModels;
        }
        public async Task<InterviewResponseModel> GetInterviewById(int id)
        {
            var interview = await _interviewRepository.GetInterviewById(id);
            var interviewResponseModel = new InterviewResponseModel
            {
                Id = interview.Id,
                BeginTime = interview.BeginTime,
                CandidateEmail = interview.CandidateEmail,
                CandidateFirstName = interview.CandidateFirstName,
                CandidateIdentityId = interview.CandidateIdentityId,
                CandidateLastName = interview.CandidateLastName,
                EndTime = interview.EndTime,
                Feedback = interview.Feedback,
                Passed = interview.Passed,
                Rating = interview.Rating,
                SubmissionId = interview.SubmissionId,
                InterviewerId = interview.InterviewerId,
                InterviewTypeId = interview.InterviewTypeId,
            };
            return interviewResponseModel;
        }
        public async Task<int> AddInterview(InterviewRequestModel model)
        {
            var interviewEntity = new Interview
            {
                BeginTime = model.BeginTime,
                CandidateEmail = model.CandidateEmail,
                CandidateFirstName = model.CandidateFirstName,
                CandidateIdentityId = model.CandidateIdentityId,
                CandidateLastName = model.CandidateLastName,
                EndTime = model.EndTime,
                Feedback = model.Feedback,
                Passed = model.Passed,
                Rating = model.Rating,
                SubmissionId = model.SubmissionId,
                InterviewerId = 1,
                InterviewTypeId = 2
            };
            var interview = await _interviewRepository.AddAsync(interviewEntity);
            return interview.Id;
        }

        // delete an employee
        public async Task<List<InterviewResponseModel>> DeleteInterview(int id)
        {
            var interviews = await _interviewRepository.DeleteInterview(id);
            if (interviews == null)
            {
                return null;
            }
            var interviewResponseModels = new List<InterviewResponseModel>();
            foreach (var interview in interviews)
            {
                var interviewResponseModel = new InterviewResponseModel
                {
                    Id = interview.Id,
                    BeginTime = interview.BeginTime,
                    CandidateEmail = interview.CandidateEmail,
                    CandidateFirstName = interview.CandidateFirstName,
                    CandidateIdentityId = interview.CandidateIdentityId,
                    CandidateLastName = interview.CandidateLastName,
                    EndTime = interview.EndTime,
                    Feedback = interview.Feedback,
                    Passed = interview.Passed,
                    Rating = interview.Rating,
                    SubmissionId = interview.SubmissionId,
                    InterviewerId = interview.InterviewerId,
                    InterviewTypeId = interview.InterviewTypeId,
                };
                interviewResponseModels.Add(interviewResponseModel);
            }
            return interviewResponseModels;
        }

        //update an employee as Interviewer
        public async Task<InterviewResponseModel> UpdateInterview(int id, InterviewRequestModel model)
        {
            var interviewEntity = new Interview
            {
                BeginTime = model.BeginTime,
                CandidateEmail = model.CandidateEmail,
                CandidateFirstName = model.CandidateFirstName,
                CandidateIdentityId = model.CandidateIdentityId,
                CandidateLastName = model.CandidateLastName,
                EndTime = model.EndTime,
                Feedback = model.Feedback,
                Passed = model.Passed,
                Rating = model.Rating,
                SubmissionId = model.SubmissionId,
            };
            var interview = await _interviewRepository.UpdateInterview(id, interviewEntity);
            if (interview == null)
            {
                return null;
            }
            var interviewResponseModel = new InterviewResponseModel
            {
                Id = interview.Id,
                BeginTime = interview.BeginTime,
                CandidateEmail = interview.CandidateEmail,
                CandidateFirstName = interview.CandidateFirstName,
                CandidateIdentityId = interview.CandidateIdentityId,
                CandidateLastName = interview.CandidateLastName,
                EndTime = interview.EndTime,
                Feedback = interview.Feedback,
                Passed = interview.Passed,
                Rating = interview.Rating,
                SubmissionId = interview.SubmissionId,
                InterviewerId = interview.InterviewerId,
                InterviewTypeId = interview.InterviewTypeId,
            };
            return interviewResponseModel;
        }
    }
}
