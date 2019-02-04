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
    public class VinculoIntegranteQueryHandler : IQueryHandler<VinculoIntegranteQuery, VinculoIntegranteQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public VinculoIntegranteQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public VinculoIntegranteQueryResult Retrieve(VinculoIntegranteQuery query)
        {
            var queryResult = new VinculoIntegranteQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<VinculoIntegranteDto>("PR_OBTENER_VINCULOS()");
            queryResult.VinculoIntegrante = (List<VinculoIntegranteDto>)querySession.List<VinculoIntegranteDto>();

            return queryResult;
        }
    }
}
