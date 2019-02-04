using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Seguridad
{
    public class ClienteDto
    {
        public string IdCliente { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public Int64 ApplicationTypeId { get; set; }
        public string Active { get; set; }
        public Int64 RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
