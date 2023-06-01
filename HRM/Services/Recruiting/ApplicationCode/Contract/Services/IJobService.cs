using ApplicationCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCode.Contract.Services
{
    public interface IJobService
    {
        Task<List<JobResponseModel>> GetAllJobs();

        Task<JobResponseModel> GetJobById(int id); // this is the method that response the UI object to the user

        Task<int> AddJob(JobRequestModel model);
    }
}
