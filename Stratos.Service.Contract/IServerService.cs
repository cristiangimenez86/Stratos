using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratos.Service.Contract.DTOs;

namespace Stratos.Service.Contract
{
    public interface IServerService
    {
        IEnumerable<ServerDTO> GetServers(int clientId);
    }
}
