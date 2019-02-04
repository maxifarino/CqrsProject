using GAP.Base;
using GAP.Base.Dto.AdministrarSalasCuna;
using GAP.Cqrs.Implementation.Query.AdministrarSalaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.AdministrarSalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.AdministrarSalasCunaQueryHandler
{
    public class AdministrarSalasCunaByFiltersQueryHandler : IQueryHandler<AdministrarSalasCunaByFiltersQuery, AdministrarSalasCunaByFiltersQueryResult>
    {
         private readonly RepositoryLocalScheme _repositryLocalScheme;

         public AdministrarSalasCunaByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

         public AdministrarSalasCunaByFiltersQueryResult Retrieve(AdministrarSalasCunaByFiltersQuery query)
        {
            var queryResult = new AdministrarSalasCunaByFiltersQueryResult();

            var querySession = _repositryLocalScheme
                    .Session
                    .CallFunction<AdministrarSalasCunaDto>("PR_OBTENER_DATOS_ADM_SC (?)")
                         

            .SetParameter(0, query.IdSalaCuna);

            queryResult.AdministrarSalasCunaDto = querySession.List<AdministrarSalasCunaDto>().First();

            return queryResult;
        }

       
    }
}
