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
    public class EmployeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateEmploye(EmployeCreateDTO employeCreateDTO)
        {
            if (employeCreateDTO == null)
                throw new ArgumentNullException("Employe argument is null!");


            Employee newEntity = new Employee()
            {
                Title = employeCreateDTO.JobTitle,
                EnrollNumber = employeCreateDTO.EnrollNumber,
                HireDate = employeCreateDTO.HireDate,
                EmployeRole=employeCreateDTO.EmployeRole,
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
                        FatherName= employeCreateDTO.FatherName,
                        BornDate= employeCreateDTO.BornDate,
                        Addres= employeCreateDTO.Addres,
                        PhoneNumber= employeCreateDTO.PhoneNumber,
                        CreatedDate= DateTime.Now,

                    }
                }
            };
            await _employeeRepository.CreateEmployee(newEntity);
        }

        public async Task UpdateEmploye(long Id, EmployeCreateDTO employeCreateDTO)
        {
            var all=await _employeeRepository.GetEmployeeById(Id);
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

        public async Task DeleteEmploye(long Id)
        {
            var employe= await _employeeRepository.GetEmployeeById(Id);
            if (employe == null)
                throw new Exception("Employe not found!");
            await _employeeRepository.DelateEmployee(employe);
        }
    }
}
