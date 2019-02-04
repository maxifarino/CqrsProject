using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class AsistenciaPersonalCursoQuery : QueryFilter
    {
        public Int64 CursoId { get; set; }
        public Int64 SalaCunaId { get; set; }
        public bool imprimirTodos { get; set; }
        public string idsPersonal { get; set; }
    }
}
