using GAP.Base;
using GAP.Base.Dto.AdministrarConvenios;
using GAP.Cqrs.Implementation.Query.AdministrarConvenios;
using GAP.Cqrs.Implementation.QueryResult.AdministrarConvenios;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.AdministrarConvenios
{
    public class ConveniosDeSalaCunaQueryHandler : IQueryHandler <ConveniosDeSalaByFiltersQuery, ConveniosDeSalaCunaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ConveniosDeSalaCunaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ConveniosDeSalaCunaQueryResult Retrieve(ConveniosDeSalaByFiltersQuery query)
        {
            var queryResult = new ConveniosDeSalaCunaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<ConveniosDeSalasCunaDto>("PR_OBTENER_CNV_SC (?)")

            .SetParameter(0, query.SalaCunaId);


            queryResult.ConveniosDeSalaCunaDto = (List<ConveniosDeSalasCunaDto>)querySession.List<ConveniosDeSalasCunaDto>();

            return queryResult;
        }


    }
}
