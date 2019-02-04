using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.FormaJuridica;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.Cqrs.Implementation.QueryResult.FormaJuridicaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.FormaJuridicaQueryHandler
{
    public class FormaJuridicaQueryHandler : IQueryHandler<FormaJuridicaByFiltersQuery, FormaJuridicaByFiltersQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public FormaJuridicaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public FormaJuridicaByFiltersQueryResults Retrieve(FormaJuridicaByFiltersQuery query)
        {
            var queryResult = new FormaJuridicaByFiltersQueryResults();

            var querySession = _repositryLocalScheme.Session.CallFunction<FormaJuridicaDto>("PR_OBTENER_FORMAS_JURIDICAS()");

            queryResult.FormaJuridicaDto = (List<FormaJuridicaDto>)querySession.List<FormaJuridicaDto>();

            return queryResult;

        }
    }
}
