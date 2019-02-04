using GAP.Base;
using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioYTutorCaracteristicasQueryHandler : IQueryHandler<BeneficiarioYTutorCaracteristicasQuery, BeneficiarioYTutorCaracteristicasQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioYTutorCaracteristicasQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioYTutorCaracteristicasQueryResult Retrieve(BeneficiarioYTutorCaracteristicasQuery query)
        {
            var queryResult = new BeneficiarioYTutorCaracteristicasQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioYTutorCaracteristicasDto>("PR_OBTENER_CARACS_BENEF_TUTOR (?)")

            .SetParameter(0, query.BeneficiarioId);

            queryResult.BeneficiarioYTutorCaracteristicas = (BeneficiarioYTutorCaracteristicasDto)querySession.UniqueResult<BeneficiarioYTutorCaracteristicasDto>();

            return queryResult;
        }
    }
}
