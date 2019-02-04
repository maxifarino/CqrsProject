using GAP.Base;
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
    public class BeneficiarioExistenciaQueryHandler : IQueryHandler<BeneficiarioCaracteristicaQuery, BeneficiarioExistenciaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioExistenciaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioExistenciaQueryResult Retrieve(BeneficiarioCaracteristicaQuery query)
        {
            var queryResult = new BeneficiarioExistenciaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioExistenciaQueryResult>("PR_VERIFICAR_BENEFICIARIO (?,?,?,?,?)")

            .SetParameter(0, query.SexoId)
            .SetParameter(1, query.NumeroDocumento)
            .SetParameter(2, query.CodigoPais)
            .SetParameter(3, query.NumeroId)
            .SetParameter(4, query.NumeroSalita);

            queryResult = (BeneficiarioExistenciaQueryResult) querySession.UniqueResult();

            return queryResult;
        }
    }
}
