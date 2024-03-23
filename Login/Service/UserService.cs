using Login.Common.DTO;
using Login.Data;
using Login.Data.Models;
using Login.IRepository;
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
            List<User> users = await _userRepository.GetAllUsers();
            if (users.Any())
            {
                foreach (var item in users)
                {
                    UserDTO user = new UserDTO()
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        Firstname = item.Person.FirstName,
                        Lastname = item.Person.LastName,
                        Fathername = item.Person.FatherName,
                        FullName = $"{item.Person.LastName} {item.Person.FirstName} {item.Person.FatherName}",
                        Addres = item.Person.Addres,
                        BornDate = item.Person.BornDate,
                        PhoneNumber = item.Person.PhoneNumber
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
            var res= await _genericRepository.GetAll(x=>x.UserName==userName && x.Password==password).FirstOrDefaultAsync() != null;
            var all=_userRepository.LoginByUserName(userName, password);
            var allUsers= _dbContext.Users.ToList();
            return res;
        }
    }
}
