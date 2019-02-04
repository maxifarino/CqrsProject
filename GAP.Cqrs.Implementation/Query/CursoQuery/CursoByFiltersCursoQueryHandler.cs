using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class CursoByFiltersCursoQueryHandler : IQueryHandler<CursoByFiltersCursoQuery, CursoByFiltersCursoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public CursoByFiltersCursoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public CursoByFiltersCursoQueryResult Retrieve(CursoByFiltersCursoQuery query)
        {
            var queryResult = new CursoByFiltersCursoQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<CursoDto>("PR_OBTENER_CURSOS_FILTROS (?,?,?,?,?,?) ")

                    .SetParameter(0, query.Nombre)
                    .SetParameter(1, query.FechaDesde)
                    .SetParameter(2, query.FechaHasta)
                    .SetParameter(3, query.IncluirDadosDeBaja == true ? 1 : 0)
                    .SetParameter(4, query.VieneParaExcel == 1 ? 0 : query.PaginationFrom)
                    .SetParameter(5, query.VieneParaExcel == 1 ? 10000 : query.PaginationTo);

            queryResult.CursosDto = (List<CursoDto>)querySession.List<CursoDto>();

            return queryResult;
        }


    }
}
