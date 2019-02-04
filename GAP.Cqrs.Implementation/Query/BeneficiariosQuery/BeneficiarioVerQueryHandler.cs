using GAP.Base;
using GAP.Base.Dto.Beneficiario;
using GAP.Cqrs.Implementation.Query.GrupoFamiliar;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioVerQueryHandler : IQueryHandler<BeneficiarioVerQuery, BeneficiarioVerQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioVerQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioVerQueryResult Retrieve(BeneficiarioVerQuery query)
        {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            var queryResult = new BeneficiarioVerQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioVerDto>("PR_VER_DATOS_BENEFICIARIO (?)")

            .SetParameter(0, query.Id);

            queryResult.Beneficiario = (BeneficiarioVerDto)querySession.UniqueResult<BeneficiarioVerDto>();

            var resultadoTutor = _queryDispatcher.Dispatch<BeneficiarioVerQuery, TutorBeneficiarioVerQueryResult>(query);

            queryResult.Tutor = resultadoTutor.TutorBeneficiarioVerDto;

            return queryResult;
        }
    }
}
