using GAP.Base;
using GAP.Base.Dto.Beneficiario;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query.BeneficiariosQuery;
using GAP.Cqrs.Implementation.QueryResult.Beneficiario;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.Beneficiario
{
    public class BeneficiarioByFiltersQueryHandler : IQueryHandler<BeneficiarioByFiltersQuery, BeneficiarioByFiltersQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioByFiltersQueryResult Retrieve(BeneficiarioByFiltersQuery query)
        {
            var queryResult = new BeneficiarioByFiltersQueryResult();

            if (GlobalVars.MockedMode)
            {
                BeneficiarioDtoMocked beneficiarioMocked = BeneficiarioDtoMocked.GetInstance();
                queryResult.Beneficiarios = beneficiarioMocked.GetMocked();
            }
            else
            {
                var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioDto>("PR_OBTENER_BENEF_SALITA (?,?,?,?,?)")

                .SetParameter(0, query.SalitaCunaId)
                .SetParameter(1, query.DadoBaja ? 1 : 0)
                .SetParameter(2, query.Especial ? 1 : 0)
                .SetParameter(3, query.PaginationFrom)
                .SetParameter(4, query.PaginationTo);


                queryResult.Beneficiarios = (List<BeneficiarioDto>)querySession.List<BeneficiarioDto>();
            }

            return queryResult;
        }
    }
}
