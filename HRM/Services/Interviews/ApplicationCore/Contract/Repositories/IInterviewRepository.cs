using ApplicationCode.Contract.Repositories;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repositories
{
    public interface IInterviewRepository : IBaseRepository<Interview>
    {
        Task<List<Interview>> GetAllInterviews();
        Task<Interview> GetInterviewById(int id);

        Task<List<Interview>> DeleteInterview(int id);
        Task<Interview> UpdateInterview(int id, Interview interview);
    }
}
