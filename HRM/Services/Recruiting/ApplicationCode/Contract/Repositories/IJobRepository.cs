using ApplicationCode.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationCode.Contract.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetPaginatedJob(int pageSize, int pageNumber);
    }
}
