using ApplicationCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseModel>> GetAllEmployees();

        Task<EmployeeResponseModel> GetEmployeeById(int id); // this is the method that response the UI object to the user

        Task<int> AddEmployee(EmployeeRequestModel model);

        Task<List<EmployeeResponseModel>> DeleteEmployee(int id);

        Task<EmployeeResponseModel> AssignInterviewer(int id);

        Task<EmployeeResponseModel> UpdateEmployee(int id, EmployeeRequestModel model);
    }
}
