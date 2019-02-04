using GAP.Base.Dto.GrupoFamiliar;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class IntegrantesByTutorQueryHandler: IQueryHandler<TutorCaracteristicaQuery, IntegranteQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public IntegrantesByTutorQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public IntegranteQueryResult Retrieve(TutorCaracteristicaQuery query)
        {
            var queryResult = new IntegranteQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<IntegranteDto>("PR_OBTENER_FAMILIAR_BY_TUTOR (?,?,?,?,?)")

            .SetParameter(0, query.NumeroId)
            .SetParameter(1, query.SexoId)
            .SetParameter(2, query.NumeroDocumento)
            .SetParameter(3, query.CodigoPais)
            .SetParameter(4, query.BeneficiarioId);

            queryResult.Integrante = (List<IntegranteDto>)querySession.List<IntegranteDto>();

            return queryResult;
        }
    }
}