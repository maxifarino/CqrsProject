using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.CursoQuery;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalCertificadoQueryHandler : IQueryHandler<AsistenciaPersonalCursoQuery, PersonalCertificadoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalCertificadoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalCertificadoQueryResult Retrieve(AsistenciaPersonalCursoQuery query)
        {
            var queryResult = new PersonalCertificadoQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalAsistenciaDto>("PR_OBTENER_PERSONAL_CERT(?,?,?)");

            querySession.SetParameter(0, query.CursoId);
            querySession.SetParameter(1, query.SalaCunaId == 0 ? -1 : query.SalaCunaId);
            querySession.SetParameter(2, query.idsPersonal);

            queryResult.ListPersonal = (List<PersonalAsistenciaDto>)querySession.List<PersonalAsistenciaDto>();

            return queryResult;
        }
    }
}
