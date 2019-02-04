using GAP.Base.Dto;
using GAP.Base.Dto.Personal;
using GAP.Cqrs.Implementation.Query.PersonQuery;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalEditQueryHandler : IQueryHandler<PersonalEditQuery, PersonalEditQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalEditQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalEditQueryResult Retrieve(PersonalEditQuery query)
        {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            var queryResult = new PersonalEditQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalDatosEditarDto>("PR_OBTENER_DATOS_PERSONAL (?,?)")

            .SetParameter(0, query.IdPersonal)
            .SetParameter(1, query.IdSalita);

            queryResult.PersonalDatosEditarDto = (PersonalDatosEditarDto)querySession.UniqueResult<PersonalDatosEditarDto>();

            var querySession3 = _repositryLocalScheme.Session.CallFunction<PersonalRequisitosDto>("PR_OBTENER_REQ_PERSONAL (?)")

           .SetParameter(0, query.IdPersonal);

            queryResult.RequisitosPersonal = (List<PersonalRequisitosDto>)querySession3.List<PersonalRequisitosDto>();

            return queryResult;
        }

    }
}
