using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
   public interface IEmployeService
    {
        Task CreateEmployee(EmployeeDTO employeCreateDTO);
        Task UpdateEmployee(long Id, EmployeeDTO employeCreateDTO);
        Task DeleteEmployee(long Id);
        public Task<List<EmployeeDTO>> GetAllEmployee();

        public Task<EmployeeDTO> GetEmployeeById(long Id);
    }
}
