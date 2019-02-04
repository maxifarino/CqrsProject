using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.Beneficiario;
using GAP.Base.Dto.Personal;
using GAP.Cqrs.Implementation.Query.GrupoFamiliar;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalVerQueryHandler : IQueryHandler<PersonalVerQuery, PersonalVerQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalVerQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalVerQueryResult Retrieve(PersonalVerQuery query)
        {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            var queryResult = new PersonalVerQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalVerDto>("PR_VER_DATOS_PERSONAL (?)")

                .SetParameter(0, query.IdAsignacionPersonal);
            //.SetParameter(1, query.IdSalita);

            queryResult.PersonalVerDto = (PersonalVerDto)querySession.UniqueResult<PersonalVerDto>();

            var querySession2 = _repositryLocalScheme.Session.CallFunction<PersonalHistorialDto>("PR_VER_HISTORIAL_PERSONAL (?)")

           .SetParameter(0, query.IdPersonal);

            queryResult.HistorialPersonal = (List<PersonalHistorialDto>)querySession2.List<PersonalHistorialDto>();

            var querySession3 = _repositryLocalScheme.Session.CallFunction<PersonalRequisitosDto>("PR_OBTENER_REQ_PERSONAL (?)")

           .SetParameter(0, query.IdPersonal);

            queryResult.RequisitosPersonal = (List<PersonalRequisitosDto>)querySession3.List<PersonalRequisitosDto>();

            var querySession4 = _repositryLocalScheme.Session.CallFunction<CursoDto>("PR_OBTENER_CURSOS_PERSONAL (?)")

           .SetParameter(0, query.IdPersonal);

            queryResult.CursosPersonal = (List<CursoDto>)querySession4.List<CursoDto>();

            return queryResult;
        }
    }
}
