using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.RolQuery
{
    public class RolAsignaByIdQueryHandler : IQueryHandler<RolAsignaByIdQuery, RolAsignaByIdQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public RolAsignaByIdQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public RolAsignaByIdQueryResult Retrieve(RolAsignaByIdQuery query)
        {
            var queryResult = new RolAsignaByIdQueryResult();

            var query1 = _repositryLocalScheme.Session.CallFunction<RolDto>("PR_OBTENER_ROLES_ASIGNA()");
                         

            queryResult.RolDto = (List<RolDto>)query1.List<RolDto>();

            return queryResult;
        }


    }
}
