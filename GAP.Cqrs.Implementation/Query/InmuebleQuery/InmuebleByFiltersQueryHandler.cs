using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult.Inmueble;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.Inmueble
{
    public class InmuebleByFiltersQueryHandler : IQueryHandler<InmuebleByFiltersQuery, InmuebleByFiltersQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public InmuebleByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public InmuebleByFiltersQueryResult Retrieve(InmuebleByFiltersQuery query)
        {
            var queryResult = new InmuebleByFiltersQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<InmuebleDto>("PR_OBTENER_INMUEBLES(?) ")

            .SetParameter(0, query.SalaCunaId);

            queryResult.InmueblesDto = (List<InmuebleDto>)querySession.List<InmuebleDto>();

            return queryResult;
        }
    }
}
