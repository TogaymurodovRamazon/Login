using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
     public interface IUserService
    {
        Task<bool> LoginByUserName(string userName, string password);
        Task<bool> LoginByPin(string pin);
        Task<List<UserDTO>> GetAllUsers();
    }
}
