using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioBySalaQueryHandler : IQueryHandler<BeneficiarioBySalaQuery, BeneficiarioBySalaQueryResult>
    {
              private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioBySalaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioBySalaQueryResult Retrieve(BeneficiarioBySalaQuery query)
        {
            var queryResult = new BeneficiarioBySalaQueryResult();


            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioDto>("PR_OBTENER_BENEF_SALA (?,?,?)")

                .SetParameter(0, query.SalaCunaId)
                .SetParameter(1, query.PaginationFrom)
                .SetParameter(2, query.PaginationTo);


            queryResult.Beneficiarios = (List<BeneficiarioDto>)querySession.List<BeneficiarioDto>();
     
            return queryResult;
        }
    }
}
