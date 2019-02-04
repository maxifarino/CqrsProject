using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class CursoByIdQueryHandler : IQueryHandler<CursoByIdQuery, CursoByIdQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public CursoByIdQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public CursoByIdQueryResult Retrieve(CursoByIdQuery query)
        {
            var queryResult = new CursoByIdQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<CursoDto>("PR_OBTENER_CURSO_BY_ID (?) ")

            .SetParameter(0, query.CursoId);

            queryResult.CursoDto = (CursoDto)querySession.UniqueResult<CursoDto>();

            return queryResult;
        }


    }
}
