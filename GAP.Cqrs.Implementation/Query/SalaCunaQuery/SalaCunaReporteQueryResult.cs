using GAP.Base.Dto.SalasCuna;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalaCunaReporteQueryResult : IQueryResult
    {
        public List<SalasCunaReporteDto> SalasCuna { get; set; }
    }
}
