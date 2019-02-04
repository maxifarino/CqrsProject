using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.RolQuery
{
    public class RolByIdQuery : IQuery
    {
        public int IdUsuario { get; set; }
        public int IdUsuarioLogueado { get; set; }
    }
}
