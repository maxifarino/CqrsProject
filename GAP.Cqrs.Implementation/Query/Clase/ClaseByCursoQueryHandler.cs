using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Clase
{
    public class ClaseByCursoQueryHandler : IQueryHandler<ClaseByCursoQuery, ClaseByCursoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ClaseByCursoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ClaseByCursoQueryResult Retrieve(ClaseByCursoQuery query)
        {
            var queryResult = new ClaseByCursoQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<ClaseDto>("PR_OBTENER_CLASE_BY_CURSO (?)")

            .SetParameter(0, query.CursoId);

            queryResult.Clase = (List<ClaseDto>)querySession.List<ClaseDto>();

            return queryResult;
        }
    }
}