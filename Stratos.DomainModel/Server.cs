using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratos.DomainModel
{
    public class Server : IKeyedEntity
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
