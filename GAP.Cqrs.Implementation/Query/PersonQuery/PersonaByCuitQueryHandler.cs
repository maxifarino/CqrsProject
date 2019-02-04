using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.PersonQuery
{
    public class PersonaByCuitQueryHandler : IQueryHandler<PersonaByCuitQuery, PersonaByCuitQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonaByCuitQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        public PersonaByCuitQueryResult Retrieve(PersonaByCuitQuery query)
        {
            var queryResult = new PersonaByCuitQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonaFisicaDto>("PR_OBTENER_PERSONA_CUIT (?)")

                .SetParameter(0, query.Cuit);

            queryResult.PersonasFisicas = (List<PersonaFisicaDto>)querySession.List<PersonaFisicaDto>();
            return queryResult;
        }


    }
}
