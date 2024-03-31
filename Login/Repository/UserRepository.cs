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

        public async Task<List<Employee>> GetAllUsers()
        {
           var users= await context.Employees.Where(a => !a.IsDeleted).Include(a => a.User).
                ThenInclude(a => a.Person).ToListAsync();
            return users;
        }

        public Task<bool> LoginByPini(string pini)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginByUserName(string userName, string password)
        {
            var res = await context.Users.FirstOrDefaultAsync(p => p.UserName == userName && p.Password == password);
            return res;
        }
    }
}
