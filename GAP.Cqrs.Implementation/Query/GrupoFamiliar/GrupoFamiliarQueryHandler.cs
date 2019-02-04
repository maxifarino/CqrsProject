using GAP.Base.Dto;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.Base.Helper;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class GrupoFamiliarQueryHandler : IQueryHandler<GrupoFamiliarQuery, GrupoFamiliarQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public GrupoFamiliarQueryHandler(RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryLocalScheme = repositryLocalScheme;
        }
        public GrupoFamiliarQueryResult Retrieve(GrupoFamiliarQuery query)
        {
            Int64 cero = 0;
            var queryResult = new GrupoFamiliarQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<GrupoFamiliarDto>("PR_REPORTE_GRUPO_FAMILIAR(?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
            querySession.SetParameter(0, query.FechaDesde != null ? query.FechaDesde : DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde));
            querySession.SetParameter(1, query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta));
            querySession.SetParameter(2, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1);
            querySession.SetParameter(3, query.SalaCunaId != null ? query.SalaCunaId : -1);
            querySession.SetParameter(4, query.Codigo);
            querySession.SetParameter(5, query.NroDocumento);
            querySession.SetParameter(6, query.DadosBaja ? 'S' : 'N');
            querySession.SetParameter(7, query.DepartamentoId != cero ? query.DepartamentoId : -1);
            querySession.SetParameter(8, query.LocalidadId != cero ? query.LocalidadId : -1);
            querySession.SetParameter(9, query.BarrioId != cero ? query.BarrioId : -1);
            querySession.SetParameter(10, query.SituacionCritica);
            querySession.SetParameter(11, query.RecibeOtroPS ? 'S' : 'N');
            querySession.SetParameter(12, query.PageNumber != null ? query.PaginationFrom : -1);
            querySession.SetParameter(13, query.PageNumber != null ? query.PaginationTo : -1);

            queryResult.ListBeneficiario = (List<GrupoFamiliarDto>)querySession.List<GrupoFamiliarDto>();
            return queryResult;
        }
    }
}
