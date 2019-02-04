using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalaCunaTieneBeneficiariosQueryHandler : IQueryHandler<SalaCunaTieneBeneficiariosQuery, SalaCunaTieneBeneficiariosQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalaCunaTieneBeneficiariosQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SalaCunaTieneBeneficiariosQueryResult Retrieve(SalaCunaTieneBeneficiariosQuery query)
         {
             var queryResult = new SalaCunaTieneBeneficiariosQueryResult();

             var querySession = _repositryLocalScheme.Session.CallFunction("PR_VERIFICAR_EXISTENCIA_BENEF(?)")

             .SetParameter(0, query.SalaCunaId);

             Result result = new Result();

             result.Resolve(querySession.UniqueResult());

             queryResult.CantidadBeneficiariosActivos = Convert.ToString(result.GetDataValue(0));
             queryResult.CantidadPersonalAsignadoCurso = Convert.ToString(result.GetDataValue(1));

             return queryResult;
         }
    }
}
