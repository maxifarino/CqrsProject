using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.SalasCuna
{
    public class SalaCunaByIdQueryHandler : IQueryHandler<SalaCunaByIdQuery, SalaCunaByIdQueryResult>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalaCunaByIdQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SalaCunaByIdQueryResult Retrieve(SalaCunaByIdQuery query)
        {
            var queryResult = new SalaCunaByIdQueryResult();

            if (GlobalVars.MockedMode)
            {
                SalasCunaDtoMocked salasMocked = SalasCunaDtoMocked.GetInstance();
                queryResult.SalaCuna = salasMocked.GetMockedById(1);
            }
            else
            {
                var querySession = _repositryLocalScheme.Session.CallFunction<SalasCunaDto>("PR_OBTENER_SALAS_CUNA_BY_ID (?) ")

                    .SetParameter(0, query.IdSalaCuna);

                List<SalasCunaDto> list = (List<SalasCunaDto>)querySession.List<SalasCunaDto>();

                queryResult.SalaCuna = list[0];
            }
            return queryResult;
        }
    }
}
