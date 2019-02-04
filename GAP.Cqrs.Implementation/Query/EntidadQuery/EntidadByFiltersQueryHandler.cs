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
    public class EntidadByFiltersQueryHandler : IQueryHandler<EntidadByFiltersQuery, EntidadByFiltersQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public EntidadByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public EntidadByFiltersQueryResult Retrieve(EntidadByFiltersQuery query)
        {
            var queryResult = new EntidadByFiltersQueryResult();

            if (GlobalVars.MockedMode)
            {
                EntidadDtoMocked entidadMocked = EntidadDtoMocked.GetInstance();
                queryResult.ListEntidades = entidadMocked.GetMocked();
            }
            else
            {
                var querysession = _repositryLocalScheme.Session.CallFunction<EntidadDto>("PR_OBTENER_ENTIDAD(?,?,?,?,?,?)")

                    .SetParameter(0, query.RazonSocial)
                    .SetParameter(1, query.Cuit)
                    .SetParameter(2, query.NombreFantasia)
                    .SetParameter(3, !query.FormaJuridicaId.HasValue ? -1 : query.FormaJuridicaId.Value)
                    .SetParameter(4, query.PaginationFrom)
                    .SetParameter(5, query.PaginationTo);
               
                queryResult.ListEntidades = (List<EntidadDto>)querysession.List<EntidadDto>();
            }

            return queryResult;
        }
    }
}
