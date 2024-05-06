using Login.Common.DTO;
using Login.Data.Models;
using Login.IRepository;
using Login.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateClient(ClinetDTO clinetDTO)
        {
            if (clinetDTO == null)
                throw new ArgumentNullException("Client argument is null");

            Client client =new Client()
            {
              PersonId=clinetDTO.Id,
              Person = new Person()
              {
                  FirstName = clinetDTO.FirstName,
                  LastName = clinetDTO.LastName,
                  FatherName = clinetDTO.FatherName,
                  BornDate = clinetDTO.BornDate,
                  Addres = clinetDTO.Addres,
                  PhoneNumber = clinetDTO.PhoneNumber,
                  CreatedDate = DateTime.Now
              }
            
            };
            await _clientRepository.CreateClient(client);
        }

        public async Task DeleteClient(long Id)
        {
            var client = await _clientRepository.GetClientById(Id);
            if (client == null)
                throw new Exception("Client not found!");
            await _clientRepository.DeleteClient(client);
        }

        public async Task<ClinetDTO> GetAllById(long Id)
        {
            var all = await _clientRepository.GetClientById(Id);
            if (all == null)
                throw new Exception("Client not found!");
            else
            {
                var client = new ClinetDTO()
                {
                    Id = all.Id,

                    FirstName = all.Person.FirstName,
                    LastName = all.Person.LastName,
                    FatherName=all.Person.FatherName,
                    BornDate =all.Person.BornDate,
                    Addres = all.Person.Addres,
                    PhoneNumber = all.Person.PhoneNumber,


                };
                return client;
            }
        }

        public async Task<List<ClinetDTO>> GetAllClient()
        {
            var client = await _clientRepository.GetAllClients();
            if (client.Any())
            {
                var allclient = client.Select(x => new ClinetDTO()
                {
                    Id = x.Id,
                    FirstName = x.Person.FirstName,
                    LastName = x.Person.LastName,
                    FatherName = x.Person.FatherName,
                    BornDate=x.Person.BornDate,
                    Addres = x.Person.Addres,
                    PhoneNumber = x.Person.PhoneNumber,

                }).ToList();
                return allclient;
            }
            return new List<ClinetDTO>();
        }

        public async Task UpdateClient(long Id, ClinetDTO clinetDTO)
        {
            var all = await _clientRepository.GetClientById(Id);
            if (all == null)
                throw new Exception("Client not found!");
            all.PersonId = clinetDTO.Id;
            all.Person = new Person()
            {
                FirstName = clinetDTO.FirstName,
                LastName = clinetDTO.LastName,
                FatherName= clinetDTO.FatherName,
                BornDate = clinetDTO.BornDate,
                Addres= clinetDTO.Addres,
                PhoneNumber= clinetDTO.PhoneNumber,
                CreatedDate = DateTime.Now
            };
            await _clientRepository.UpdateClient(all);
        }
    }
}
