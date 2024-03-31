using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.IRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DelateEmployee(Employee employee);
        Task<Employee> GetEmployeeById(long Id);

        Task<List<Employee>> GetAllEmployees();
    }
}
