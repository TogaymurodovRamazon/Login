using Login.Data;
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
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext context;
        public UserRepository(AppDBContext _context)
        {
           this.context = _context;
        }

        public async Task<List<User>> GetAllUsers()
        {
           var users= await context.Users.Where(x=>!x.IsDeleted).Include(s=>s.Person).ToListAsync();
            return users;
        }

        public Task<bool> LoginByPini(string pini)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginByUserName(string userName, string password)
        {
            var res = context.Users.FirstOrDefault(p => p.UserName == userName && p.Password == password);
            return res != null;
        }
    }
}
