using ApplicationCode.Contract.Repositories;
using ApplicationCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCode.Models;

namespace Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository 
    {
        public CandidateRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Candidate> UpdateResume(int id, string newResumeURL)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            if (candidate == null) return null;
            candidate.ResumeURL = newResumeURL;
            await _dbContext.SaveChangesAsync();
            return candidate;
        }

        //add new candidate id into the new submission
        public async Task<Candidate> AddSubmission(int id, Submission submission)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            if (candidate == null) return null;
            _dbContext.Submissions.Add(submission);
            await _dbContext.SaveChangesAsync();
            return candidate;
        }
    }
}
