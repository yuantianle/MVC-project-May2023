using ApplicationCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCode.Contract.Repositories
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<Candidate> UpdateResume(int id, string newResumeURL);
        Task<Candidate> AddSubmission(int id, Submission submission);
    }
}
