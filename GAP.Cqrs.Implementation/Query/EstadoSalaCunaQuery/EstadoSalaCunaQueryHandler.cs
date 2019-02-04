using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.EstadoSalaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.EstadoSalaCunaQueryResult;
using NHibernate.Transform;
using GAP.Repository.LocalScheme;
using GAP.CqrsCore.Querys;
using GAP.Base;

namespace GAP.Cqrs.Implementation.QueryHandler.EstadoSalaCuna
{
    public class EstadoSalaCunaQueryHandler : IQueryHandler<EstadoSalaCunaByFiltersQuery, EstadoSalaCunaByFiltersQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public EstadoSalaCunaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public EstadoSalaCunaByFiltersQueryResults Retrieve(EstadoSalaCunaByFiltersQuery query)
        {
            var queryResult = new EstadoSalaCunaByFiltersQueryResults();

            var querySession = _repositryLocalScheme.Session.CallFunction<EstadoSalaCunaDto>("PR_OBTENER_EST_SAL_CUN() ");

           queryResult.EstadoSalaCunaDto = (List<EstadoSalaCunaDto>)querySession.List<EstadoSalaCunaDto>();

           return queryResult;

       }
    }
}
