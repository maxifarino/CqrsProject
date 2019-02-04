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
    public class IntegranteQueryHandler : IQueryHandler<IntegranteQuery, IntegranteQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public IntegranteQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public IntegranteQueryResult Retrieve(IntegranteQuery query)
        {
            var queryResult = new IntegranteQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<IntegranteDto>("PR_OBTENER_GPO_FLIAR(?,?)");
               querySession.SetParameter(0, query.BeneficiarioId);
               querySession.SetParameter(1,query.CasoDeUso);

            queryResult.Integrante = (List<IntegranteDto>)querySession.List<IntegranteDto>();

            return queryResult;
        }
    }
}
