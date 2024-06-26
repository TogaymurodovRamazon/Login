﻿using Login.Data;
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
            var hasCopy = await _dbContext.Employees.AnyAsync(a => !a.IsDeleted && (employee.EmployeRole == Data.Enum.EmployePole.Admin ?
            a.User.UserName == employee.User.UserName : false));
            if (hasCopy)
                throw new Exception("Currect username alredy exist!");
            await _dbContext.Employees.AddAsync(employee);
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

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _dbContext.Employees.Where(a => !a.IsDeleted).Include(a => a.User).
                ThenInclude(a => a.Person).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(long Id)
        {
            if (Id < 0)
                throw new Exception("Id is low from 0!");
            return await _dbContext.Employees.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == Id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
