using GAP.Base;
using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioCaracteristicaQueryHandler : IQueryHandler<BeneficiarioCaracteristicaQuery, BeneficiarioCaracteristicaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioCaracteristicaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioCaracteristicaQueryResult Retrieve(BeneficiarioCaracteristicaQuery query)
        {
            var queryResult = new BeneficiarioCaracteristicaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioCaracteristicaDto>("PR_OBTENER_DATOS_BENEFICIARIO (?,?,?,?)")

            .SetParameter(0, query.NumeroId)
            .SetParameter(1, query.SexoId)
            .SetParameter(2, query.CodigoPais)
            .SetParameter(3, query.NumeroDocumento);

            queryResult.BeneficiarioCaracteristica = (BeneficiarioCaracteristicaDto)querySession.UniqueResult<BeneficiarioCaracteristicaDto>();

            return queryResult;
        }
    }
}
