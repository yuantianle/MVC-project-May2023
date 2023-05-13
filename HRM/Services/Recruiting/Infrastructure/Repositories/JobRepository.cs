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
    public class JobRepository : IJobRepository
    {
        protected readonly RecruitingDbContext _dbContext;
        public JobRepository(RecruitingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Job>> GetPaginatedJob(int pageSize, int pageNumber)
        {
            var jobs = await _dbContext.Jobs.Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
            return jobs;
        }
    }
}
