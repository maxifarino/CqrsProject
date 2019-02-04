using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class CursoInscriptosBajaQueryResult : IQueryResult
    {
        public string CantidadInscriptosBaja { get; set; }
        public string CantidadInscriptosAlta { get; set; }
    }
}
