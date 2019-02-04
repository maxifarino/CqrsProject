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

using NHibernate.Transform;
using GAP.Base;
using GAP.Base.Mock;
namespace GAP.Cqrs.Implementation.QueryHandler.SalasCuna
{
    public class SalasCunaByFiltersQueryHandler : IQueryHandler<SalasCunaByFiltersQuery, SalasCunaByFiltersQueryResults>
    {
         private readonly RepositoryLocalScheme _repositryLocalScheme;

         public SalasCunaByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

         public SalasCunaByFiltersQueryResults Retrieve(SalasCunaByFiltersQuery query)
         {
             var queryResult = new SalasCunaByFiltersQueryResults();

             if (GlobalVars.MockedMode)
             {
                 SalasCunaDtoMocked salasMocked = SalasCunaDtoMocked.GetInstance();
                 queryResult.SalasCunaDto = salasMocked.GetMocked();
             } 
             else
             {
                 var querySession = _repositryLocalScheme.Session.CallFunction<SalasCunaDto>("PR_OBTENER_SALAS_CUNA (?,?,?,?,?,?,?,?) ")

                     .SetParameter(0, query.RazonSocial)
                     .SetParameter(1, query.Cuit)
                     .SetParameter(2, query.NombreFantasia)
                     .SetParameter(3, !query.EstadoId.HasValue ? -1 : query.EstadoId.Value)
                     .SetParameter(4, query.NombreSalaCuna)
                     .SetParameter(5, query.Codigo)
                     .SetParameter(6, query.PaginationFrom)
                     .SetParameter(7, query.PaginationTo);

                 queryResult.SalasCunaDto = (List<SalasCunaDto>)querySession.List<SalasCunaDto>();
             }

             return queryResult;
         }
    }
}






