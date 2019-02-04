using GAP.Base;
using GAP.Base.Dto;
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
    public class BeneficiarioTutorByFiltersQueryHandler : IQueryHandler<BeneficiarioByFiltersQuery, BeneficiarioTutorByFiltersQueryResult>
    {

          private readonly RepositoryLocalScheme _repositryLocalScheme;

          public BeneficiarioTutorByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

          public BeneficiarioTutorByFiltersQueryResult Retrieve(BeneficiarioByFiltersQuery query)
        {
            var queryResult = new BeneficiarioTutorByFiltersQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioTutorDto>("PR_OBTENER_BEN_Y_TUTOR(?)")

            .SetParameter(0, query.BeneficiarioId);

            queryResult.BeneficiarioTutor = (BeneficiarioTutorDto)querySession.UniqueResult<BeneficiarioTutorDto>();

            return queryResult;
        }

    }
}
