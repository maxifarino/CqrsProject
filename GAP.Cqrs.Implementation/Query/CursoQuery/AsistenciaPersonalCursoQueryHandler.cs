using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class AsistenciaPersonalCursoQueryHandler : IQueryHandler<AsistenciaPersonalCursoQuery, AsistenciaPersonalCursoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public AsistenciaPersonalCursoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public AsistenciaPersonalCursoQueryResult Retrieve(AsistenciaPersonalCursoQuery query)
        {
            var queryResult = new AsistenciaPersonalCursoQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalAsistenciaDto>("PR_REPORTE_ASIST_PERS_CURSO (?,?)")

                .SetParameter(0, query.CursoId)
                .SetParameter(1, query.SalaCunaId == 0 ? -1 : query.SalaCunaId);

            queryResult.ListPersonal = (List<PersonalAsistenciaDto>)querySession.List<PersonalAsistenciaDto>();

            return queryResult;
        }
    }
}
