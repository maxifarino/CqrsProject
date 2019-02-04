using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.EntidadQuery
{
    public class SalaCunaVerEntidadQueryResult : IQueryResult
    {
        public List<SalaCunaVerEntidadDto> SalaCunaVerEntidadDto { get; set; }
    }
}