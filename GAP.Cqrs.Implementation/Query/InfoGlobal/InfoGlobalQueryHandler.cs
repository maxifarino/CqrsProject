using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.InfoGlobal
{
    public class InfoGlobalQueryHandler : IQueryHandler<InfoGlobalQuery, InfoGlobalQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public InfoGlobalQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public InfoGlobalQueryResults Retrieve(InfoGlobalQuery query)
        {
            Int64 cero = 0;
            var queryResult = new InfoGlobalQueryResults();
            var querySession = _repositryLocalScheme.Session.CallFunction<InfoGlobalDto>("PR_REPORTE_INFO_GLOBAL(?,?,?,?,?,?,?,?,?,?,?)")
                .SetParameter(0, query.FechaDesde)
                .SetParameter(1, query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : query.FechaHasta)
                .SetParameter(2, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
                .SetParameter(3, query.SalaCunaId != null ? query.SalaCunaId : -1)
                .SetParameter(4, query.Codigo)
                .SetParameter(5, query.DepartamentoId != cero ? query.DepartamentoId : -1)
                .SetParameter(6, query.LocalidadId != cero ? query.LocalidadId : -1)
                .SetParameter(7, query.BarrioId != cero ? query.BarrioId : -1)
                .SetParameter(8, query.SituacionCritica)
                .SetParameter(9, query.Ubicacion)
                .SetParameter(10, -1);

            queryResult.DatosGlobales = (List<InfoGlobalDto>)querySession.List<InfoGlobalDto>();

            return queryResult;
        }
    }
}
