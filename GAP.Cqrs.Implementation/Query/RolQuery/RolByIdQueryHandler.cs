using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.RolQuery;
using GAP.Cqrs.Implementation.QueryResult.Rol;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.Rol
{
    public class RolByIdQueryHandler : IQueryHandler<RolByIdQuery, RolByIdQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public RolByIdQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        public RolByIdQueryResults Retrieve(RolByIdQuery query)
        {
            var queryResult = new RolByIdQueryResults();

            var query1 = _repositryLocalScheme.Session.CallFunction<RolDto>("PR_OBTENER_ROLES(?,?)")
                         .SetParameter(0, query.IdUsuario)
                         .SetParameter(1, query.IdUsuarioLogueado);

            queryResult.RolDto = (List<RolDto>)query1.List<RolDto>();

            return queryResult;
        }

    }
}
