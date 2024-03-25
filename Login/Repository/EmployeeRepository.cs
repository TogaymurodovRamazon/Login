using Login.Data;
using Login.Data.Models;
using Login.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _dbContext;
        public EmployeeRepository(AppDBContext dBContext)
        {
            this._dbContext = dBContext;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var hasCopy=await _dbContext.Employees.AnyAsync(x=>x.User.UserName == employee.User.UserName);
            if (hasCopy)
                throw new Exception("Currect username alredy exist!");
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;

        }

        public async Task DelateEmployee(Employee employee)
        {
            //_dbContext.Employees.Remove(employee);
            employee.IsDeleted = true;
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeById(long id)
        {
            if (id < 0)
                throw new Exception("Id is low from 0!");
            return await _dbContext.Employees.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
