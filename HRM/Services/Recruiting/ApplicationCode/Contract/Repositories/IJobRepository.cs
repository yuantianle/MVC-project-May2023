using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCode.Entities;


namespace ApplicationCode.Contract.Repositories
{
    public interface IJobRepository : IBaseRepository<Job>
    {

        Task<List<Job>> GetAllJobs();
        Task<Job> GetJobById(int id);
    }
}
