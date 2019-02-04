using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.SucursalQuery;
using GAP.Cqrs.Implementation.QueryResult.SucursalQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.SucursalQueryHandler
{
    public class SucursalQueryHandler : IQueryHandler<SucursalByEntidadBancariaQuery,SucursalByEntidadBancariaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SucursalQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SucursalByEntidadBancariaQueryResult Retrieve(SucursalByEntidadBancariaQuery query)
        {
            var queryResult = new SucursalByEntidadBancariaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<SucursalDto>("PR_OBTENER_SUCURSALES(?)")
                         .SetParameter(0, query.idEntidadBancaria);

            queryResult.Sucursales = (List<SucursalDto>)querySession.List<SucursalDto>();

            return queryResult;

        }
    }
}
