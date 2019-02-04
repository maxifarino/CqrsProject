using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalasCunaByFiltersCursoQueryHandler : IQueryHandler<SalasCunaByFiltersCursoQuery, SalasCunaByFiltersCursoQueryResult>
    {
         private readonly RepositoryLocalScheme _repositryLocalScheme;

         public SalasCunaByFiltersCursoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

         public SalasCunaByFiltersCursoQueryResult Retrieve(SalasCunaByFiltersCursoQuery query)
         {
             var queryResult = new SalasCunaByFiltersCursoQueryResult();

             if (GlobalVars.MockedMode)
             {
                 SalasCunaDtoMocked salasMocked = SalasCunaDtoMocked.GetInstance();
                 queryResult.SalasCunaDto = salasMocked.GetMocked();
             } 
             else
             {
                 var querySession = _repositryLocalScheme.Session.CallFunction<SalasCunaDto>("PR_OBTENER_SALAS_CURSO (?,?,?,?,?) ")

                     .SetParameter(0, query.NombreSalaCuna)
                     .SetParameter(1, query.Codigo)
                     .SetParameter(2, query.EstadoId)                   
                     .SetParameter(3, query.PaginationFrom)
                     .SetParameter(4, query.PaginationTo);

                 queryResult.SalasCunaDto = (List<SalasCunaDto>)querySession.List<SalasCunaDto>();
             }

             return queryResult;
         }
    }
}
