using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Usuario
{
    public class UsuarioDto
    {
        public Int64 IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cuil { get; set; }
        public string Rol { get; set; }
        public Int64 IdRol { get; set; }
        public string Sexo { get; set; }



    }
}
