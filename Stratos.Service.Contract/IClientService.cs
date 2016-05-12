using Stratos.Service.Contract.DTOs;
using System.Collections.Generic;

namespace Stratos.Service.Contract
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetClients();
        IEnumerable<ClientDTO> SearchClients(string criteria);
        ClientDTO GetClient(int id);
        void InsertClient(ClientDTO client);
        void UpdateClient(ClientDTO client);
        void DeleteClient(int id);
    }
}
