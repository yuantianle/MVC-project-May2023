using ApplicationCode.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCode.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {

        public JobRepository(RecruitingDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Job>> GetAllJobs()
        {
            // go to the database and get the data
            // EF Core with LinQ
            var jobs = await _dbContext.Jobs.ToListAsync() ;
            return jobs;
        }

        public async Task<Job> GetJobById(int id)
        {
            var job = await _dbContext.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            return job;
        }
    }
}
