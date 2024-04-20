using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Login.IRepository
{
   public interface IClientRepository
    {
        Task<List<Client>> GetAllClients();
        Task<Client> CreateClient(Client client);
        Task<Client> UpdateClient(Client client);
        Task DeleteClient(Client client);
        Task<Client> GetClientById(long Id);

    }
}
