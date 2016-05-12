﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratos.Service.Contract.DTOs
{
    public class ServerDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
