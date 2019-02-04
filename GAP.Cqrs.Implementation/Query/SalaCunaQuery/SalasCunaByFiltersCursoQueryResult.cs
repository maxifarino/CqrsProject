using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalasCunaByFiltersCursoQueryResult : IQueryResult
    {
        public List<SalasCunaDto> SalasCunaDto { get; set; }
    }
}
