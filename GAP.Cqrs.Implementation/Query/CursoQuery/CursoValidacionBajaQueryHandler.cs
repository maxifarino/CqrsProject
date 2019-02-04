using GAP.Base.Dto;
using GAP.Base.Dto.Personal;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Curso
{
    public class CursoValidacionBajaQueryHandler : IQueryHandler<CursoValidacionBajaQuery, CursoValidacionBajaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public CursoValidacionBajaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public CursoValidacionBajaQueryResult Retrieve(CursoValidacionBajaQuery query)
        {
            var queryResult = new CursoValidacionBajaQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<CursoValidacionBajaDto>("PR_VALIDAR_BAJA_CURSO (?)")

            .SetParameter(0, query.CursoId);

            queryResult.Validacion = (CursoValidacionBajaDto)querySession.UniqueResult();

            return queryResult;
        }
    }
}