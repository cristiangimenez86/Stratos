using Stratos.DataAccess.Repositories;
using Stratos.DomainModel;
using Stratos.Service.Contract;
using Stratos.Service.Contract.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Stratos.Service.Implementation
{
    public class ClientService : ServiceBase, IClientService
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            var clientsEntity = _clientRepository.Query().Take(50).ToList();

            var clientsDto = clientsEntity.Select(
                x => new ClientDTO {
                    Email = x.Email, 
                    Id = x.Id, Name = 
                    x.Name, 
                    Phone = x.Phone 
                })
                .ToList();

            return clientsDto;
        }

        public ClientDTO GetClient(int id)
        {
            var clientEntity = _clientRepository.Query().SingleOrDefault(x => x.Id == id);

            ClientDTO client = null;
            
            if (clientEntity != null)
            {
                client = new ClientDTO
                {
                    Id = clientEntity.Id,
                    Name = clientEntity.Name,
                    Email = clientEntity.Email,
                    Phone = clientEntity.Phone
                };
            }
            
            return client;
        }

        public IEnumerable<ClientDTO> SearchClients(string criteria)
        {
            var clientsEntity = _clientRepository.Query().Where(x => x.Name.Contains(criteria)).ToList();

            var clientsDto = clientsEntity.Select(
                x => new ClientDTO
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.Phone
                })
                .ToList();

            return clientsDto;
        }

        public void InsertClient(ClientDTO client)
        {
            var clientEntity = new Client
            {
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone
            };

            _clientRepository.Add(clientEntity);
            _clientRepository.Save();
        }

        public void UpdateClient(ClientDTO client)
        {
            var clientEntity = _clientRepository.Query().SingleOrDefault(x => x.Id == client.Id);

            if (clientEntity != null)
            {
                clientEntity.Name = client.Name;
                clientEntity.Email = client.Email;
                clientEntity.Phone = client.Phone;

                _clientRepository.Update(clientEntity);
                _clientRepository.Save();
            }
        }

        public void DeleteClient(int id)
        {
            var clientEntity = _clientRepository.Query().SingleOrDefault(x => x.Id == id);

            if (clientEntity != null)
            {
                _clientRepository.Delete(clientEntity);
                _clientRepository.Save();
            }
        }
    }
}
