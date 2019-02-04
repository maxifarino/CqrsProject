using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.AdministrarConvenios;
using GAP.Cqrs.Implementation.Query.AdministrarRequisitos;
using GAP.Cqrs.Implementation.Query.BandejaSalasCunaQuery;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.Cqrs.Implementation.Query.SalitaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.AdministrarConvenios;
using GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos;
using GAP.Cqrs.Implementation.QueryResult.Inmueble;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.Cqrs.Implementation.QueryResult.SalitaCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class SalaCunaByCursoQueryHandler : IQueryHandler<SalaCunaByCursoQuery, SalaCunaByCursoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalaCunaByCursoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SalaCunaByCursoQueryResult Retrieve(SalaCunaByCursoQuery query)
         {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            var queryResult = new SalaCunaByCursoQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<SalasCunaByCursoDto>("PR_OBTENER_SALAS_BY_CURSO (?) ")

            .SetParameter(0, query.CursoId);

            var resultado = (List<SalasCunaByCursoDto>)querySession.List<SalasCunaByCursoDto>();
            queryResult.ListSalaCunaDto = resultado;

            return queryResult;
         }
    }
}
