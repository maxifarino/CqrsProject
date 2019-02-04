using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities.Seguridad
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public bool Active { get; set; }
        public Int64 RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
