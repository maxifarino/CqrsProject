using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class SalaCunaByCursoQueryResult : IQueryResult
    {
        public List<SalasCunaByCursoDto> ListSalaCunaDto { get; set; }
    }
}
