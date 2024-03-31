using Login.Common.DTO;
using Login.Data;
using Login.Data.Models;
using Login.IRepository;
using Login.Variables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenericRepository<User> _genericRepository;
        private readonly AppDBContext _dbContext;

        public UserService(IUserRepository userRepository, IGenericRepository<User> genericRepository, AppDBContext dBContext)
        {
            this. _userRepository = userRepository;
            this. _genericRepository = genericRepository;
            this. _dbContext = dBContext;
            
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            List<Employee> users = await _userRepository.GetAllUsers();
            if (users.Any())
            {
                foreach (var item in users)
                {
                    UserDTO user = new UserDTO()
                    {
                        Id = item.Id,
                        UserName = item.User.UserName,
                        Firstname = item.User.Person.FirstName,
                        Lastname = item.User.Person.LastName,
                        Fathername = item.User.Person.FatherName,
                        FullName = $"{item.User.Person.LastName} {item.User.Person.FirstName} {item.User.Person.FatherName}",
                        Addres = item.User.Person.Addres,
                        BornDate = item.User.Person.BornDate,
                        PhoneNumber = item.User.Person.PhoneNumber
                    };
                    userDTOs.Add(user);
                }
                return userDTOs;
            }
            return userDTOs;
        }

        public async Task<bool> LoginByPin(string pin)
        {
            return await _genericRepository.GetAll(x=>x.PIN==pin).FirstOrDefaultAsync() != null;
        }

        public async Task<bool> LoginByUserName(string userName, string password)
        {
           
            var all=await _userRepository.LoginByUserName(userName, password);
            StaticVariable.CurrentUserName = all.UserName;
            return all != null;
        }
    }
}
