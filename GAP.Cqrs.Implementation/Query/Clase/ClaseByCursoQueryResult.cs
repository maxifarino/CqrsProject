using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Clase
{
    public class ClaseByCursoQueryResult : IQueryResult
    {
        public List<ClaseDto> Clase { get; set; }
    }
}
