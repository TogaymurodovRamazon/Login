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

namespace Login.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDBContext _appDBContext;
        public ClientRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Client> CreateClient(Client client)
        {
            var hasCopy = await _appDBContext.Clients.AnyAsync(a => !a.IsDeleted);
            if (hasCopy)
                throw new Exception("Currect alredy exist!");
            await _appDBContext.Clients.AddAsync(client);
            await _appDBContext.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClient(Client client)
        {
           client.IsDeleted = true;
            _appDBContext.Update(client);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _appDBContext.Clients.Where(x => !x.IsDeleted).Include(a => a.Person).ToListAsync();
        }

        public async Task<Client> GetClientById(long Id)
        {
            if (Id < 0)
                throw new Exception("Id is low from 0 !");
            var resalt= await _appDBContext.Clients.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == Id);
            return resalt;
        }

        public async Task<Client> UpdateClient(Client client)
        {
            _appDBContext.Clients.Update(client);
            await _appDBContext.SaveChangesAsync();
            return client;
        }
    }
}
