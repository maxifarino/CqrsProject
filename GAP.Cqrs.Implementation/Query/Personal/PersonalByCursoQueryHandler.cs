using GAP.Base.Dto.Personal;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalByCursoQueryHandler : IQueryHandler<PersonalByCursoQuery, PersonalByCursoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalByCursoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalByCursoQueryResult Retrieve(PersonalByCursoQuery query)
        {
            var queryResult = new PersonalByCursoQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalDto>("PR_OBTENER_PERSONAL_BY_CURSO (?)")

            .SetParameter(0, query.CursoId);

            queryResult.Personal = (List<PersonalDto>)querySession.List<PersonalDto>();

            return queryResult;
        }
    }
}