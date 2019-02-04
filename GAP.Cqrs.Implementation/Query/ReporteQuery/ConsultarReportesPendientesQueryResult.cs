using GAP.Base.Dto.Reportes;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ReporteQuery
{
    public class ConsultarReportesPendientesQueryResult : IQueryResult
    {
        public ReportesPendientesDto ReportesPendientesDto { get; set; }
    }
}
