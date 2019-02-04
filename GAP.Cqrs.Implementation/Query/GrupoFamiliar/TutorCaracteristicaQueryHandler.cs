using GAP.Base;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class TutorCaracteristicaQueryHandler : IQueryHandler<TutorCaracteristicaQuery, TutorCaracteristicaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public TutorCaracteristicaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public TutorCaracteristicaQueryResult Retrieve(TutorCaracteristicaQuery query)
        {

            var queryResult = new TutorCaracteristicaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<TutorBeneficiarioCaracteristicaDto>("PR_OBTENER_DATOS_TUTOR (?,?,?,?,?,?,?,?)")

            .SetParameter(0, query.NumeroId)
            .SetParameter(1, query.SexoId)
            .SetParameter(2, query.CodigoPais)
            .SetParameter(3, query.NumeroDocumento)
            .SetParameter(4, query.NumeroIdBeneficiario)
            .SetParameter(5, query.SexoIdBeneficiario)
            .SetParameter(6, query.CodigoPaisBeneficiario)
            .SetParameter(7, query.NumeroDocumentoBeneficiario);

            queryResult.TutorBeneficiarioCaracteristicaDto = (TutorBeneficiarioCaracteristicaDto)querySession.UniqueResult<TutorBeneficiarioCaracteristicaDto>();

            EsBeneficiario(query, queryResult);

            return queryResult;
        }
        public void EsBeneficiario(TutorCaracteristicaQuery query, TutorCaracteristicaQueryResult queryResult)
        {
            Result result = new Result();

            var querySession = _repositryLocalScheme.Session.CallFunction("PR_VALIDAR_ES_BENEF(?,?,?,?)")
                  .SetParameter(0, query.NumeroDocumento)
                  .SetParameter(1, query.CodigoPais)
                  .SetParameter(2, query.SexoId)
                  .SetParameter(3, query.NumeroId);
            result.Resolve(querySession.UniqueResult());
            if (queryResult.TutorBeneficiarioCaracteristicaDto == null)
            {
                queryResult.TutorBeneficiarioCaracteristicaDto = new TutorBeneficiarioCaracteristicaDto();
            }
            if (result.Data != null)
            {
                queryResult.TutorBeneficiarioCaracteristicaDto.Existe = Convert.ToString(result.GetDataValue(0));

            }

        }
    }
}
