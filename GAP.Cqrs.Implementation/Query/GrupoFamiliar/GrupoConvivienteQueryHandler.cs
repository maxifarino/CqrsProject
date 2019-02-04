using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.CqrsCore.Querys;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.Repository.LocalScheme;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class GrupoConvivienteQueryHandler : IQueryHandler<IntegranteQuery, GrupoConvivienteQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public GrupoConvivienteQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public GrupoConvivienteQueryResult Retrieve(IntegranteQuery query)
        {
            var queryResult = new GrupoConvivienteQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<IntegranteResumenDto>("PR_OBTENER_GPO_FLIAR_RESUMEN(?,?)");
               querySession.SetParameter(0, query.BeneficiarioId);
               querySession.SetParameter(1,query.CasoDeUso);

               queryResult.Integrante = (List<IntegranteResumenDto>)querySession.List<IntegranteResumenDto>();

            return queryResult;
        }
    }
}
