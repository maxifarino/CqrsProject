using GAP.Base.Dto.Reportes;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ReporteQuery
{
    public class ConsultarReportesPendientesQueryHandler : IQueryHandler<ConsultarReportesPendientesQuery, ConsultarReportesPendientesQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ConsultarReportesPendientesQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ConsultarReportesPendientesQueryResult Retrieve(ConsultarReportesPendientesQuery query)
        {
            var queryResult = new ConsultarReportesPendientesQueryResult();
            var query1 = _repositryLocalScheme.Session.CallFunction<ReportesPendientesDto>("PR_OBTENER_PROCESO_COLA()");
            queryResult.ReportesPendientesDto = (ReportesPendientesDto)query1.UniqueResult<ReportesPendientesDto>();
            return queryResult;
        }
    }
}
