using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.Cqrs.Implementation.QueryResult.EntidadQuery;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.Entidad
{
    public class GetAllEntidadQueryHandler : IQueryHandler<GetAllEntidadQuery, GetAllEntidadQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public GetAllEntidadQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public GetAllEntidadQueryResult Retrieve(GetAllEntidadQuery query)
        {
            var queryResult = new GetAllEntidadQueryResult();

            if (GlobalVars.MockedMode)
            {
                EntidadDtoMocked entidadMocked = EntidadDtoMocked.GetInstance();
                queryResult.ListEntidades = entidadMocked.GetAllMocked();
            }
            else
            {
                var querysession = _repositryLocalScheme.Session.CallFunction<EntidadComboDto>("PR_OBTENER_ENTIDADES_SC()");
                queryResult.ListEntidades = (List<EntidadComboDto>)querysession.List<EntidadComboDto>();
            }

            return queryResult;
        }
    }
}
