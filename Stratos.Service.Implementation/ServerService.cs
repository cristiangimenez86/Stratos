using Stratos.DataAccess.Repositories;
using Stratos.DomainModel;
using Stratos.Service.Contract;
using Stratos.Service.Contract.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Stratos.Service.Implementation
{
    public class ServerService : ServiceBase, IServerService
    {
        private readonly IRepository<Server> _serverRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly ICryptoService _cryptoService;

        public ServerService(
            IRepository<Server> serverRepository, 
            IRepository<Client> clientRepository,
            ICryptoService cryptoService)
        {
            _serverRepository = serverRepository;
            _clientRepository = clientRepository;
            _cryptoService = cryptoService;
        }

        public IEnumerable<ServerDTO> GetServers(int clientId)
        {
            var serversEntity = _serverRepository.Query().Where(x => x.Client.Id == clientId).ToList();

            var serversDto = serversEntity.Select(x => new ServerDTO
            {
                URL = x.URL,
                Username = x.Username,
                Password = _cryptoService.Decrypt(x.Password),
                Id = x.Id,
                ClientId = x.ClientId
            }).ToList();

            return serversDto;
        }

        public ServerDTO GetServer(int id)
        {
            ServerDTO server = null;

            var serverEntity = _serverRepository.Query().SingleOrDefault(x => x.Id == id);
            if (serverEntity != null)
            {
                server = new ServerDTO
                {
                    Id = serverEntity.Id,
                    URL = serverEntity.URL,
                    Username = serverEntity.Username,
                    Password = _cryptoService.Decrypt(serverEntity.Password),
                    ClientId = serverEntity.Client.Id
                };
            }

            return server;
        }

        public void InsertServer(ServerDTO server)
        {
            var serverEntity = new Server
            {
                URL = server.URL,
                Username = server.Username,
                Password = _cryptoService.Encrypt(server.Password),
                Client = _clientRepository.Query().SingleOrDefault(x=>x.Id == server.ClientId)
            };

            _serverRepository.Add(serverEntity);
            _serverRepository.Save();
        }

        public void UpdateServer(ServerDTO server)
        {
            var serverEntity = _serverRepository.Query().SingleOrDefault(x => x.Id == server.Id);

            if (serverEntity != null)
            {
                serverEntity.URL = server.URL;
                serverEntity.Username = server.URL;
                serverEntity.Password = _cryptoService.Encrypt(server.Password);

                _serverRepository.Update(serverEntity);
                _serverRepository.Save();
            }
        }

        public void DeleteServer(int id)
        {
            var serverEntity = _serverRepository.Query().SingleOrDefault(x => x.Id == id);

            if (serverEntity != null)
            {
                _serverRepository.Delete(serverEntity);
                _serverRepository.Save();
            }
        }
    }
}