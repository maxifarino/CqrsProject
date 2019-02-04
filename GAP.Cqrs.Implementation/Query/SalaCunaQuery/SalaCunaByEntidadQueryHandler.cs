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
    public class SalaCunaByEntidadQueryHandler : IQueryHandler<SalaCunaByEntidadQuery, SalaCunaByEntidadQueryResult>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalaCunaByEntidadQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SalaCunaByEntidadQueryResult Retrieve(SalaCunaByEntidadQuery query)
        {
            var queryResult = new SalaCunaByEntidadQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<SalasCunaComboDto>("PR_OBTENER_SC_BY_ID_PJ (?)")

                .SetParameter(0, query.EntidadId);

            queryResult.ListSalasCuna = (List<SalasCunaComboDto>)querySession.List<SalasCunaComboDto>();

            return queryResult;
        }
    }
}
