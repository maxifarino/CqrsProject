using GAP.Base.Dto;
using GAP.Base.Dto.Beneficiario;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class CantidadBeneficiariosQueryHandler : IQueryHandler<CantidadBeneficiariosQuery, CantidadBeneficiariosQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public CantidadBeneficiariosQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public CantidadBeneficiariosQueryResult Retrieve(CantidadBeneficiariosQuery query)
        {
            var queryResult = new CantidadBeneficiariosQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioVerDto>("PR_OBTENER_CANT_BENEF ()");

            queryResult.BeneficiarioVerDto = (BeneficiarioVerDto)querySession.UniqueResult<BeneficiarioVerDto>();

            return queryResult;
        }
    }
}
