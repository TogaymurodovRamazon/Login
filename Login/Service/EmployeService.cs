using Login.Common.DTO;
using Login.Data.Models;
using Login.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public class EmployeService : IEmployeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateEmployee(EmployeeDTO employeCreateDTO)
        {
            if (employeCreateDTO == null)
                throw new ArgumentNullException("Employe argument is null!");


            Employee newEntity = new Employee()
            {
                Title = employeCreateDTO.JobTitle,
                EnrollNumber = employeCreateDTO.EnrollNumber,
                HireDate = employeCreateDTO.HireDate,
                EmployeRole = employeCreateDTO.EmployeRole,
                CreatedDate = DateTime.Now,
                User = new User()
                {
                    UserName = employeCreateDTO.UserName,
                    Password = employeCreateDTO.Password,
                    PIN = employeCreateDTO.PIN,
                    CreatedDate = DateTime.Now,
                    Person = new Person()
                    {
                        FirstName = employeCreateDTO.FirstName,
                        LastName = employeCreateDTO.LastName,
                        FatherName = employeCreateDTO.FatherName,
                        BornDate = employeCreateDTO.BornDate,
                        Addres = employeCreateDTO.Addres,
                        PhoneNumber = employeCreateDTO.PhoneNumber,
                        CreatedDate = DateTime.Now,

                    }
                }
            };
            await _employeeRepository.CreateEmployee(newEntity);
        }

        public async Task UpdateEmployee(long Id, EmployeeDTO employeCreateDTO)
        {
            var all = await _employeeRepository.GetEmployeeById(Id);
            if (all == null)
                throw new Exception("Employe not found!");

            all.Title = employeCreateDTO.JobTitle;
            all.EnrollNumber = employeCreateDTO.EnrollNumber;
            all.HireDate = employeCreateDTO.HireDate;
            all.EmployeRole = employeCreateDTO.EmployeRole;
            all.CreatedDate = DateTime.Now;
            all.User = new User()
            {
                UserName = employeCreateDTO.UserName,
                Password = employeCreateDTO.Password,
                PIN = employeCreateDTO.PIN,
                CreatedDate = DateTime.Now,
                Person = new Person()
                {
                    FirstName = employeCreateDTO.FirstName,
                    LastName = employeCreateDTO.LastName,
                    FatherName = employeCreateDTO.FatherName,
                    BornDate = employeCreateDTO.BornDate,
                    Addres = employeCreateDTO.Addres,
                    PhoneNumber = employeCreateDTO.PhoneNumber,
                    CreatedDate = DateTime.Now,
                }
            };
            await _employeeRepository.UpdateEmployee(all);
        }

        public async Task DeleteEmployee(long Id)
        {
            var employe = await _employeeRepository.GetEmployeeById(Id);
            if (employe == null)
                throw new Exception("Employe not found!");
            await _employeeRepository.DelateEmployee(employe);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
           var employe = await _employeeRepository.GetAllEmployees();
            if (employe.Any())
            {
                var allemployes = employe.Select(a => new EmployeeDTO()
                {
                    Id = a.Id,
                    JobTitle = a.Title,
                    HireDate = a.HireDate,
                    EnrollNumber = a.EnrollNumber,
                    EmployeRole = a.EmployeRole,

                    UserName = a.User.UserName,
                    FirstName = a.User.Person.FirstName,
                    LastName = a.User.Person.LastName,
                    FatherName = a.User.Person.FatherName,
                    BornDate = a.User.Person.BornDate,
                    Addres = a.User.Person.Addres,
                    PhoneNumber = a.User.Person.PhoneNumber,
                    FullName = $"{a.User.Person.LastName} {a.User.Person.FirstName} {a.User.Person.FatherName}"
                }).ToList();
                return allemployes;
            }
            return new List<EmployeeDTO>();
        }

        public async Task<EmployeeDTO> GetEmployeeById(long Id)
        {
            var all=await _employeeRepository.GetEmployeeById(Id);
            if (all == null)
                throw new Exception("Employee not fount!");
            else
            {
                var employe = new EmployeeDTO()
                {
                    Id = all.Id,
                    JobTitle = all.Title,
                    HireDate = all.HireDate,
                    EnrollNumber = all.EnrollNumber,
                    EmployeRole = all.EmployeRole,

                    UserName = all.User.UserName,
                    FirstName = all.User.Person.FirstName,
                    LastName = all.User.Person.LastName,
                    FatherName = all.User.Person.FatherName,
                    BornDate = all.User.Person.BornDate,
                    Addres = all.User.Person.Addres,
                    PhoneNumber = all.User.Person.PhoneNumber,
                    FullName = $"{all.User.Person.LastName} {all.User.Person.FirstName} {all.User.Person.FatherName}"
                };
                return employe;
            }
        }
    }
}
