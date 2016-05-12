using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratos.DomainModel
{
    public class Client : IKeyedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public virtual ICollection<Server> Servers { get; set; }
    }
}
