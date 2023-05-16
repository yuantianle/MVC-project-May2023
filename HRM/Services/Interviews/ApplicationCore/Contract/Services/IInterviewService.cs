using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface IInterviewService
    {
        Task<List<InterviewResponseModel>> GetAllInterviews();

        Task<InterviewResponseModel> GetInterviewById(int id); // this is the method that response the UI object to the user

        Task<int> AddInterview(InterviewRequestModel model);

        Task<List<InterviewResponseModel>> DeleteInterview(int id);

        Task<InterviewResponseModel> UpdateInterview(int id, InterviewRequestModel model);
    }
}
