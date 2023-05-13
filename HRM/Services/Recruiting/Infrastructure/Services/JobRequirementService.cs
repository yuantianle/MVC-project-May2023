using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCode.Contract.Repositories;
using ApplicationCode.Contract.Services;
using ApplicationCode.Models;

namespace Infrastructure.Services
{
    public class JobRequirementService : IJobRequirementService
    {
        private readonly IJobRepository _jobRepository; // dependency injection

        public JobRequirementService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        // Implement paginated result set for Task<IEnumerable<JobResponseModel>> GetPaginatedJob(int pageSize = 30, int pageNumber = 1)
        public async Task<IEnumerable<JobResponseModel>> GetPaginatedJob(int pageSize = 30, int pageNumber = 1)
        {
            var jobs = await _jobRepository.GetPaginatedJob(pageSize, pageNumber);

            // Convert entities to response models
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
    }


}
