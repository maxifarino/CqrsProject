﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities.Seguridad
{
    public class RefreshToken
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string ClientId { get; set; }
        public DateTime? IssuedUtc { get; set; }
        public DateTime? ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
