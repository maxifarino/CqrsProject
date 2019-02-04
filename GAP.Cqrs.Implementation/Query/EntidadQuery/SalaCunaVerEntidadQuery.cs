using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.EntidadQuery
{
    public class SalaCunaVerEntidadQuery : IQuery
    {
        public Int64 Cuil { get; set; }
        public string IdSede { get; set; }

        public int idUsuarioLogueado { get; set; }
    }
}