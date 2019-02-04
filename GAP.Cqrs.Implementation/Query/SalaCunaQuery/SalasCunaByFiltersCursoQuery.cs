using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalasCunaByFiltersCursoQuery : QueryFilter
    {
        public string Codigo { get; set; }
        public string NombreSalaCuna { get; set; }
        public string EstadoId { get; set; }
    }
}
