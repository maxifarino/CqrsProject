using GAP.Base.ResultValidation;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class CursoInscriptosBajaQueryHandler : IQueryHandler<CursoInscriptosBajaQuery, CursoInscriptosBajaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public CursoInscriptosBajaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public CursoInscriptosBajaQueryResult Retrieve(CursoInscriptosBajaQuery query)
        {
            var queryResult = new CursoInscriptosBajaQueryResult();

            if (query.IdCurso != 0)
            {
                var query2 = _repositryLocalScheme.Session.CallFunction("PR_VERIFICAR_INSC_A_DAR_BAJA(?,?,?)")

                .SetParameter(0, query.IdCurso)
                .SetParameter(1, query.Salas)
                .SetParameter(2, query.Cargos);

                Result result = new Result();

                result.Resolve(query2.UniqueResult());

                queryResult.CantidadInscriptosBaja = Convert.ToString(result.GetDataValue(0));
                queryResult.CantidadInscriptosAlta = Convert.ToString(result.GetDataValue(1));
            }
            else
            {

                var query2 = _repositryLocalScheme.Session.CallFunction("PR_VERIFICAR_INSC_ALTA(?,?)")

                .SetParameter(0, query.Salas)
                .SetParameter(1, query.Cargos);

                Result result = new Result();

                result.Resolve(query2.UniqueResult());

                queryResult.CantidadInscriptosAlta = Convert.ToString(result.GetDataValue(0));
            }

            return queryResult;
        }
    }
}
