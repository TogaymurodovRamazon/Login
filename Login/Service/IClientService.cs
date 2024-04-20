using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public interface IClientService
    {
        public Task CreateClient(ClinetDTO clinetDTO);
        public Task UpdateClient(long Id, ClinetDTO clinetDTO);
        public Task DeleteClient(long Id);
        public Task<List<ClinetDTO>> GetAllClient();
        public Task<ClinetDTO> GetAllById(long Id);
    }
}
