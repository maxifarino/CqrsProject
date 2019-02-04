using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalAsistioByClaseQueryHandler: IQueryHandler<PersonalInscriptoByFilterQuery, PersonalAsistioByClaseQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalAsistioByClaseQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalAsistioByClaseQueryResult Retrieve(PersonalInscriptoByFilterQuery query)
        {
            var queryResult = new PersonalAsistioByClaseQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalAsistioDto>("PR_ASISTENCIA_PERS_BY_CURSO (?,?)");

            querySession.SetParameter(0, query.CursoId);
            querySession.SetParameter(1, query.ClaseId);

            queryResult.ListPersonalAsistio = (List<PersonalAsistioDto>)querySession.List<PersonalAsistioDto>();

            return queryResult;
        }
    }
}