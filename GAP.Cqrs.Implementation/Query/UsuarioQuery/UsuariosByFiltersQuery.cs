using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
   public class UsuariosByFiltersQuery : QueryFilter
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Rol { get; set; }   
        public bool IncluirDadosDeBaja { get; set; }
        public string Cuil { get; set; }
    }
}
