using GAP.Base.Dto;
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
    public class PersonalInscriptoByFilterQueryHandler: IQueryHandler<PersonalInscriptoByFilterQuery, PersonalInscriptoByFilterQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalInscriptoByFilterQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalInscriptoByFilterQueryResult Retrieve(PersonalInscriptoByFilterQuery query)
        {
            var queryResult = new PersonalInscriptoByFilterQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalAsistenciaDto>("PR_OBTENER_PERS_INSC_BY_FILTER (?,?,?,?,?,?,?)");

            querySession.SetParameter(0, query.CursoId);
            querySession.SetParameter(1, query.ClaseId);
            querySession.SetParameter(2, query.Documento);
            querySession.SetParameter(3, query.Nombre);
            querySession.SetParameter(4, query.Apellido);
            querySession.SetParameter(5, query.PaginationFrom);
            querySession.SetParameter(6, query.PaginationTo);

            queryResult.ListInscripto = (List<PersonalAsistenciaDto>)querySession.List<PersonalAsistenciaDto>();

            return queryResult;
        }
    }
}