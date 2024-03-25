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
        Task CreateEmployee(EmployeCreateDTO employeCreateDTO);
        Task UpdateEmployee(long Id, EmployeCreateDTO employeCreateDTO);
        Task DeleteEmployee(long Id);
    }
}
