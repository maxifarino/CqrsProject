using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.RolQuery;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.Cqrs.Implementation.QueryResult.Rol;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using GAP.Base;

namespace GAP.Cqrs.Implementation.QueryHandler.Rol
{
    public class RolQueryHandler : IQueryHandler<RolByFiltersQuery, RolByFiltersQueryResults>
    {


        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public RolQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        public RolByFiltersQueryResults Retrieve(RolByFiltersQuery query)
        {
            var queryResult = new RolByFiltersQueryResults();

            var query1 = _repositryLocalScheme.Session.CallFunction<RolDto>("PR_OBTENER_ROLES()");

            queryResult.RolDto = (List<RolDto>)query1.List<RolDto>();

            return queryResult;
        }


    }
}
