using ApplicationCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCode.Contract.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidates();
        Task<CandidateResponseModel> GetCandidateById(int id);
        Task<int> AddCandidate(CandidateRequestModel model, int jobid);
        Task<CandidateResponseModel> UpdateCandidateResume(int id, string newResumeURL);

    }
}
