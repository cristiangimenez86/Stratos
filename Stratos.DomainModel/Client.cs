﻿using System.Collections.Generic;

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
