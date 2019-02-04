using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Usuario
{
    public class UsuarioCidiDto
    {
        public Int64 Id { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cuil { get; set; }
        public Int64 IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Email { get; set; }

    }
}
