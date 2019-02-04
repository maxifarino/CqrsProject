using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.BandejaSalasCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.SalasCuna
{
    public class SalasCunaBandejaByIdQueryHandler : IQueryHandler<SalasCunaBandejaByIdQuery, SalasCunaBandejaByIdQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalasCunaBandejaByIdQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SalasCunaBandejaByIdQueryResults Retrieve(SalasCunaBandejaByIdQuery query)
        {
            var queryResult = new SalasCunaBandejaByIdQueryResults();

            var querySession = _repositryLocalScheme.Session.CallFunction<SalasCunaBandejaDto>("PR_OBTENER_SC_BANDEJA (?,?) ")
                  .SetParameter(0, query.IdSalaCuna == 0 ? -1 : query.IdSalaCuna)
                  .SetParameter(1, query.CodigoSalaCuna);

            queryResult.SalasCunaBandejaDto = (List<SalasCunaBandejaDto>)querySession.List<SalasCunaBandejaDto>();

            return queryResult;
        }

    }
}
