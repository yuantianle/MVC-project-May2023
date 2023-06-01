using ApplicationCode.Contract.Repositories;
using ApplicationCode.Contract.Services;
using ApplicationCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCode.Entities;

namespace Infrastructure.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository; //dependency injection
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<JobResponseModel>> GetAllJobs()
        {
            
            var jobs = await _jobRepository.GetAllJobs();
            // convert entity to response model
            var jobResponseModels = new List<JobResponseModel>();
            foreach (var job in jobs)
            {
                var jobResponseModel = new JobResponseModel
                {
                    Id = job.Id,
                    Title = job.Title,
                    Description = job.Description,
                    StartDate = job.StartDate.GetValueOrDefault(),
                    NumberOfPositions = job.NumberOfPositions
                };
                jobResponseModels.Add(jobResponseModel);
            }
            return jobResponseModels;
        }

        public async Task<JobResponseModel> GetJobById(int id)
        {
            var job = await _jobRepository.GetJobById(id);
            if (job == null) return null;
            // convert entity to response model
            var jobResponseModel = new JobResponseModel
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                StartDate = job.StartDate.GetValueOrDefault()
            };
            return jobResponseModel;
        }

        public async Task<int> AddJob(JobRequestModel model)
        {
            var jobEntity = new Job 
            {  
                Title = model.Title,
                StartDate = model.StartDate,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow, 
                NumberOfPositions = model.NumberOfPositions,
                JobStatusLookUpId = 1
            };

            var job = await _jobRepository.AddAsync(jobEntity);
            return job.Id;
        }
    }
}
