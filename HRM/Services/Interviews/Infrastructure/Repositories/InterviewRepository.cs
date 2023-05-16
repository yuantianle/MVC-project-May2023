using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Infrastructure.Repositories
{
    public class InterviewRepository : BaseRepository<Interview>, IInterviewRepository
    {
        public InterviewRepository(InterviewsDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Interview>> GetAllInterviews()
        {
            //var Employees = await _dbContext.Employees.ToListAsync();
            //return Employees;
            //get all the employees with pagination version :)
            var Interviews = await _dbContext.Interviews.Skip(0).Take(10).ToListAsync();
            return Interviews;
        }
        public async Task<Interview> GetInterviewById(int id)
        {
            var Interviews = await _dbContext.Interviews.FirstOrDefaultAsync(x => x.Id == id);
            return Interviews;
        }

        //DeleteAsync
        public async Task<List<Interview>> DeleteInterview(int id)
        {
            var Interviews = await _dbContext.Interviews.FirstOrDefaultAsync(x => x.Id == id);
            if (Interviews == null) return null;
            _dbContext.Interviews.Remove(Interviews);
            await _dbContext.SaveChangesAsync();
            var nowdb = await _dbContext.Interviews.Skip(0).Take(10).ToListAsync();
            return nowdb;
        }

        //UpdateAsync
        public async Task<Interview> UpdateInterview(int id, Interview interview)
        {
            var InterviewUpdate = await _dbContext.Interviews.FirstOrDefaultAsync(x => x.Id == id);
            if (InterviewUpdate == null) return null;
            InterviewUpdate.BeginTime = interview.BeginTime;
            InterviewUpdate.CandidateEmail = interview.CandidateEmail;
            InterviewUpdate.CandidateFirstName = interview.CandidateFirstName;
            InterviewUpdate.CandidateIdentityId = interview.CandidateIdentityId;
            InterviewUpdate.CandidateLastName = interview.CandidateLastName;
            InterviewUpdate.EndTime = interview.EndTime;
            InterviewUpdate.Feedback = interview.Feedback;
            InterviewUpdate.Passed = interview.Passed;
            InterviewUpdate.Rating = interview.Rating;
            InterviewUpdate.SubmissionId = interview.SubmissionId;
            InterviewUpdate.InterviewerId = interview.InterviewerId;
            InterviewUpdate.InterviewTypeId = interview.InterviewTypeId;
            await _dbContext.SaveChangesAsync();
            return InterviewUpdate;
        }
    }
}
