using ApplicationCode.Contract.Repositories;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);

        Task<List<Employee>> DeleteEmployee(int id);
        Task<Employee> AssignInterviewer(int id);
        Task<Employee> UpdateEmployee(int id, Employee employee);
    }
}
