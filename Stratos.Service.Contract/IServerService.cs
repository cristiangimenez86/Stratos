using Stratos.Service.Contract.DTOs;
using System.Collections.Generic;

namespace Stratos.Service.Contract
{
    public interface IServerService
    {
        IEnumerable<ServerDTO> GetServers(int clientId);
        ServerDTO GetServer(int id);
        void InsertServer(ServerDTO server);
        void UpdateServer(ServerDTO server);
        void DeleteServer(int id);
    }
}
