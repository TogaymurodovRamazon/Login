using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.IRepository
{
      public interface IUserRepository
    {
        Task<bool> LoginByUserName(string userName, string password);
        Task<bool> LoginByPini(string pini);
        Task<List<User>> GetAllUsers();
    }
}
