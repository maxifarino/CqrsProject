using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.SalitaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.SalitaCunaQueryResult;
using NHibernate.Transform;
using GAP.Base;
using GAP.Base.Mock;

namespace GAP.Cqrs.Implementation.QueryHandler.SalitaCunaQueryHandler
{
    public class SalitaCunaByFiltersQueryHandler : IQueryHandler<SalitaCunaByFiltersQuery, SalitaCunaByFiltersQueryResults>
    {
        public bool DeBaja = false;
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public SalitaCunaByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public SalitaCunaByFiltersQueryResults Retrieve(SalitaCunaByFiltersQuery query)
        {
            var queryResult = new SalitaCunaByFiltersQueryResults();
            if (GlobalVars.MockedMode)
            {
                SalitaCunaDtoMocked salasMocked = SalitaCunaDtoMocked.GetInstance();
                queryResult.listSalitas = salasMocked.GetMocked();
            }
            else
            {
                var querySession = _repositryLocalScheme.Session.CallFunction<SalitasCunaDto>("PR_OBTENER_SALITAS_BENEF(?,?,?,?) ")
                             .SetParameter(0, query.SalaCunaId)
                             .SetParameter(1, query.SeleccionBaja ? 1 : 0)
                             .SetParameter(2, query.PaginationFrom)
                             .SetParameter(3, query.PaginationTo);
                queryResult.listSalitas = (List<SalitasCunaDto>)querySession.List<SalitasCunaDto>();
            }

            return queryResult;
        }

    }
}
