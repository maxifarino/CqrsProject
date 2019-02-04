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
    public class BeneficiarioExistenciaModQueryHandler : IQueryHandler<BeneficiarioCaracteristicaModQuery, BeneficiarioExistenciaModQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioExistenciaModQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioExistenciaModQueryResult Retrieve(BeneficiarioCaracteristicaModQuery query)
        {
            var queryResult = new BeneficiarioExistenciaModQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioExistenciaModQueryResult>("PR_VERIFICAR_BENEFICIARIO_MOD (?,?,?,?,?)")

            .SetParameter(0, query.SexoId)
            .SetParameter(1, query.NumeroDocumento)
            .SetParameter(2, query.CodigoPais)
            .SetParameter(3, query.NumeroId)
            .SetParameter(4, query.NumeroSalita);

            queryResult = (BeneficiarioExistenciaModQueryResult) querySession.UniqueResult();

            return queryResult;
        }
    }
}
