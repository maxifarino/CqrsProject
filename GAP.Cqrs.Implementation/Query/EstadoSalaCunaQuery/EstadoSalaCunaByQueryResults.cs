using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;
using GAP.CqrsCore.Querys;

namespace GAP.Cqrs.Implementation.QueryResult.EstadoSalaCunaQueryResult
{
    public class EstadoSalaCunaByFiltersQueryResults : IQueryResult
    {
        public List<EstadoSalaCunaDto> EstadoSalaCunaDto { get; set; }
    }
}
