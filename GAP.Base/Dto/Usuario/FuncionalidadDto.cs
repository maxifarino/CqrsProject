
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Usuario
{
    public class FuncionalidadDto
    {
        public string Path { get; set; }
        public string EsPagina { get; set; }
        public string Role { get; set; }
        public string Descripcion { get; set; }
        public Int64 IdPadre { get; set; }
        public Int64 Id { get; set; }
    }
}
