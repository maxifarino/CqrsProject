using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental
{
    public class ReporteSocioAmbientalByFiltersQueryHandler : IQueryHandler<ReporteSocioAmbientalByFiltersQuery, ReporteSocioAmbientalByFiltersQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public ReporteSocioAmbientalByFiltersQueryHandler(RepositoryLocalScheme repository) {
            _repositryLocalScheme = repository;
        }
        public ReporteSocioAmbientalByFiltersQueryResults Retrieve(ReporteSocioAmbientalByFiltersQuery query)
        {
            Int64 cero = 0;
            var queryResult = new ReporteSocioAmbientalByFiltersQueryResults();
            var querySession = _repositryLocalScheme.Session.CallFunction<SocioAmbientalDto>("PR_CONS_REP_SOCIO_AMBIENTAL(?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
                .SetParameter(0, query.SocioAmbientalId != null ? query.SocioAmbientalId : -1)
                .SetParameter(1, query.FechaDesde)
                .SetParameter(2, query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : query.FechaHasta)
                .SetParameter(3, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
                .SetParameter(4, query.SalaCunaId != null ? query.SalaCunaId : -1)
                .SetParameter(5, query.Codigo)
                .SetParameter(6, query.NroDocumento)
                .SetParameter(7, query.DadosBaja ? 'S' : 'N')
                .SetParameter(8, query.DepartamentoId != cero ? query.DepartamentoId : -1)
                .SetParameter(9, query.LocalidadId != cero ? query.LocalidadId : -1)
                .SetParameter(10, query.BarrioId != cero ? query.BarrioId : -1)
                .SetParameter(11, query.SituacionCritica)
                .SetParameter(12, query.PageNumber != null ? query.PaginationFrom : 0)
                .SetParameter(13, query.PageNumber != null ? query.PaginationTo : 10000);

            queryResult.LstSocioAmbiental = (List<SocioAmbientalDto>)querySession.List<SocioAmbientalDto>();
            
            return queryResult;

        }
    }
}
