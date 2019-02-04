using GAP.Base;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.Cqrs.Implementation.Query.BeneficiariosQuery;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class TutorBeneficiarioVerQueryHandler : IQueryHandler<BeneficiarioVerQuery, TutorBeneficiarioVerQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public TutorBeneficiarioVerQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public TutorBeneficiarioVerQueryResult Retrieve(BeneficiarioVerQuery query)
        {
            var queryResult = new TutorBeneficiarioVerQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<TutorBeneficiarioVerDto>("PR_VER_DATOS_TUTOR (?)")
                     
            .SetParameter(0, query.Id);

            queryResult.TutorBeneficiarioVerDto = (TutorBeneficiarioVerDto)querySession.UniqueResult<TutorBeneficiarioVerDto>();

            return queryResult;
        }
    }
}
