using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratos.DataAccess.Repositories;
using Stratos.DomainModel;
using Stratos.Service.Contract;
using Stratos.Service.Contract.DTOs;

namespace Stratos.Service.Implementation
{
    public class ServerService : IServerService
    {
        private readonly IRepository<Server> _serverRepository;

        public ServerService(IRepository<Server> serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public IEnumerable<ServerDTO> GetServers(int clientId)
        {
            var serversEntity = _serverRepository.Query().Where(x => x.ClientId == clientId).ToList();

            var serversDto = serversEntity.Select(x => new ServerDTO
            {
                URL = x.URL,
                Username = x.Username,
                Password = x.Password
            }).ToList();

            return serversDto;
        }
    }
}
