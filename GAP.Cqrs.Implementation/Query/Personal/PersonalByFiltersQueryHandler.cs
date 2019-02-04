using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;
using NHibernate.Transform;
using GAP.Base;
using GAP.Base.Mock;
using GAP.Base.Dto.Personal;
using GAP.Cqrs.Implementation.QueryResult.PersonalQueryResult;
namespace GAP.Cqrs.Implementation.QueryHandler.Personal
{
    public class PersonalByFiltersQueryHandler : IQueryHandler<PersonalByFiltersQuery, PersonalByFiltersQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalByFiltersQueryResults Retrieve(PersonalByFiltersQuery query)
        {
            var queryResult = new PersonalByFiltersQueryResults();

            if (GlobalVars.MockedMode)
            {
                List<PersonalDto> PersonalDto = null;
                queryResult.PersonalDto = PersonalDto;

            }
            else
            {
                var querySession = _repositryLocalScheme.Session.CallFunction<PersonalDto>("PR_OBTENER_PERSONAL_SC(?,?,?,?,?)")

                    .SetParameter(0, query.SalaId)
                    .SetParameter(1, query.TurnoSalaId == 0 ? -1 : query.TurnoSalaId)
                    .SetParameter(2, query.DadoBaja ? 1 : -1)
                    .SetParameter(3, query.PaginationFrom)
                    .SetParameter(4, query.PaginationTo);

                queryResult.PersonalDto = (List<PersonalDto>)querySession.List<PersonalDto>();
            }

            return queryResult;
        }
    }
}