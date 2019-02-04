using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class VerificarBeneficiarioSalaQueryHandler : IQueryHandler<VerificarBeneficiarioSalaQuery, VerificarBeneficiarioSalaQueryResult>
    {

         private readonly RepositoryLocalScheme _repositryLocalScheme;

         public VerificarBeneficiarioSalaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }



         public VerificarBeneficiarioSalaQueryResult Retrieve(VerificarBeneficiarioSalaQuery query)
         {
             var queryResult = new VerificarBeneficiarioSalaQueryResult();

             var querySession = _repositryLocalScheme.Session.CallFunction<VerificarBeneficiarioSalaDto>("PR_OBTENER_CARACS_BENEF_TUTOR (?)")

             .SetParameter(0, query.BeneficiarioId);

             queryResult.VerificarBeneficiarioSalaDto = (VerificarBeneficiarioSalaDto)querySession.UniqueResult<VerificarBeneficiarioSalaDto>();

             return queryResult;
         }

    }
}
