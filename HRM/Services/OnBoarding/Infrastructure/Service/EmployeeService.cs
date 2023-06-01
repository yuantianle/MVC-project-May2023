using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contract.Services;
using ApplicationCode.Models;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;

namespace Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeResponseModel>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            var employeeResponseModels = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                var employeeResponseModel = new EmployeeResponseModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName, 
                    Email = employee.Email,
                    SSN = employee.SSN,
                    Address = employee.Address,
                    EmployeeIdentityId = employee.EmployeeIdentityId,
                    HireDate = employee.HireDate.GetValueOrDefault(),
                    EndDate = employee.EndDate.GetValueOrDefault(),
                    MiddleName = employee.MiddleName,
                    EmployeeStatusId = employee.EmployeeStatusId
                };
                employeeResponseModels.Add(employeeResponseModel);
            } 
            return employeeResponseModels;
        }        
        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            var employeeResponseModel = new EmployeeResponseModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                SSN = employee.SSN,
                Address = employee.Address,
                EmployeeIdentityId = employee.EmployeeIdentityId,
                HireDate = employee.HireDate.GetValueOrDefault(),
                EndDate = employee.EndDate.GetValueOrDefault(),
                MiddleName = employee.MiddleName,
                EmployeeStatusId = employee.EmployeeStatusId
            };
            return employeeResponseModel;
        }        
        public async Task<int> AddEmployee(EmployeeRequestModel model)
        {
            var employeeEntity = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName, 
                Email = model.Email,
                SSN = model.SSN,
                Address = model.Address,
                EmployeeIdentityId = model.EmployeeIdentityId,
                HireDate = model.HireDate.GetValueOrDefault(),
                EndDate = model.EndDate.GetValueOrDefault(),
                MiddleName = model.MiddleName,
                EmployeeStatusId = 0
            };
            var employee =  await _employeeRepository.AddAsync(employeeEntity);
            return employee.Id;
        }

        // delete an employee
        public async Task<List<EmployeeResponseModel>> DeleteEmployee(int id)
        {
            var employees = await _employeeRepository.DeleteEmployee(id);
            if (employees == null)
            {
                return null;
            }
            var employeeResponseModels = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                var employeeResponseModel = new EmployeeResponseModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    SSN = employee.SSN,
                    Address = employee.Address,
                    EmployeeIdentityId = employee.EmployeeIdentityId,
                    HireDate = employee.HireDate.GetValueOrDefault(),
                    EndDate = employee.EndDate.GetValueOrDefault(),
                    MiddleName = employee.MiddleName,
                    EmployeeStatusId = employee.EmployeeStatusId
                };
                employeeResponseModels.Add(employeeResponseModel);
            }
            return employeeResponseModels;
        }

        //assign an employee as Interviewer
        public async Task<EmployeeResponseModel> AssignInterviewer(int id)
        {
            var employee = await _employeeRepository.AssignInterviewer(id);
            var employeeResponseModel = new EmployeeResponseModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                SSN = employee.SSN,
                Address = employee.Address,
                EmployeeIdentityId = employee.EmployeeIdentityId,
                HireDate = employee.HireDate.GetValueOrDefault(),
                EndDate = employee.EndDate.GetValueOrDefault(),
                MiddleName = employee.MiddleName,
                EmployeeStatusId = employee.EmployeeStatusId
            };
            return employeeResponseModel;
        }

        //update an employee as Interviewer
        public async Task<EmployeeResponseModel> UpdateEmployee(int id, EmployeeRequestModel model)
        {
            var employeeEntity = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                SSN = model.SSN,
                Address = model.Address,
                EmployeeIdentityId = model.EmployeeIdentityId,
                HireDate = model.HireDate.GetValueOrDefault(),
                EndDate = model.EndDate.GetValueOrDefault(),
                MiddleName = model.MiddleName
            };
            var employee = await _employeeRepository.UpdateEmployee(id, employeeEntity);
            if (employee == null)
            {
                return null;
            }
            var employeeResponseModel = new EmployeeResponseModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                SSN = employee.SSN,
                Address = employee.Address,
                EmployeeIdentityId = employee.EmployeeIdentityId,
                HireDate = employee.HireDate.GetValueOrDefault(),
                EndDate = employee.EndDate.GetValueOrDefault(),
                MiddleName = employee.MiddleName,
                EmployeeStatusId = employee.EmployeeStatusId
            };
            return employeeResponseModel;
        }
    }
}
