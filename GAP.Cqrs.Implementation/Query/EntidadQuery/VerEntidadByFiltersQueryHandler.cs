using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.EntidadQuery;
using GAP.Cqrs.Implementation.QueryResult.EntidadQuery;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.Entidad
{
    public class VerEntidadByFiltersQueryHandler : IQueryHandler<VerEntidadByFiltersQuery, VerEntidadByFiltersQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

         public VerEntidadByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

         public VerEntidadByFiltersQueryResult Retrieve(VerEntidadByFiltersQuery query)
         {
             var queryResult = new VerEntidadByFiltersQueryResult();
             QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();

             var querysession = _repositryLocalScheme.Session.CallFunction<EntidadDetalleDto>("PR_OBTENER_ENTIDAD_VER(?,?,?)")

             .SetParameter(0, query.Cuil)
             .SetParameter(1, query.IdSede)
             .SetParameter(2, GlobalVars.IdApplication);

             var resultado = (List<EntidadDetalleDto>)querysession.List<EntidadDetalleDto>();
             queryResult.EntidadDetalleDto = resultado.First();

             var querySalas = new SalaCunaVerEntidadQuery { Cuil = (Int64)query.Cuil, IdSede = query.IdSede };
             var resultadoSalas = _queryDispatcher.Dispatch<SalaCunaVerEntidadQuery, SalaCunaVerEntidadQueryResult>(querySalas);

             queryResult.EntidadDetalleDto.SalasCunas = resultadoSalas.SalaCunaVerEntidadDto;

             return queryResult;
         }

    }
}
