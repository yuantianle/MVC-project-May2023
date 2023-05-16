using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OnBoardingDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            //var Employees = await _dbContext.Employees.ToListAsync();
            //return Employees;
            //get all the employees with pagination version :)
            var Employees = await _dbContext.Employees.Skip(0).Take(10).ToListAsync();
            return Employees;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            var Employees = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return Employees;
        }

        //DeleteAsync
        public async Task<List<Employee>> DeleteEmployee(int id)
        {
            var Employees = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (Employees == null) return null;
            _dbContext.Employees.Remove(Employees);
            await _dbContext.SaveChangesAsync();
            var nowdb = await _dbContext.Employees.Skip(0).Take(10).ToListAsync();
            return nowdb;
        }

        //AssignInterviewer
        public async Task<Employee> AssignInterviewer(int id)
        {
            var Employees = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (Employees == null) return null;
            Employees.EmployeeStatusId = 4;
            await _dbContext.SaveChangesAsync();
            return Employees;
        }

        //UpdateAsync
        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var EmployeeUpdate = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (EmployeeUpdate == null) return null;
            EmployeeUpdate.FirstName = employee.FirstName;
            EmployeeUpdate.LastName = employee.LastName;
            EmployeeUpdate.Email = employee.Email;
            EmployeeUpdate.SSN = employee.SSN;
            EmployeeUpdate.Address = employee.Address;
            EmployeeUpdate.EmployeeIdentityId = employee.EmployeeIdentityId;
            EmployeeUpdate.HireDate = employee.HireDate.GetValueOrDefault();
            EmployeeUpdate.EndDate = employee.EndDate.GetValueOrDefault();
            EmployeeUpdate.MiddleName = employee.MiddleName;
            EmployeeUpdate.EmployeeStatusId = employee.EmployeeStatusId;
            await _dbContext.SaveChangesAsync();
            return EmployeeUpdate;
        }
    }
}
