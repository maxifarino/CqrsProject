using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class ObtenerUsuarioActivoQuery : IQuery
    {
        public string Hash { get; set; }
    }
}
