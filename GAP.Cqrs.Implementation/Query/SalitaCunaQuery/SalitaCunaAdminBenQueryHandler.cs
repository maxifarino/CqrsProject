using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Mock;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalitaCunaQuery
{
    public class SalitaCunaAdminBenQueryHandler : IQueryHandler <SalitaCunaAdminBenQuery, SalitaCunaAdminBenQueryResult>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public SalitaCunaAdminBenQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public SalitaCunaAdminBenQueryResult Retrieve(SalitaCunaAdminBenQuery query)
        {
            var queryResult = new SalitaCunaAdminBenQueryResult();

            if (GlobalVars.MockedMode)
            {
                SalitaCunaDtoMocked salasMocked = SalitaCunaDtoMocked.GetInstance();
                queryResult.SalitasCunaDto = salasMocked.GetMocked();
            }
            else
            {

                var querySession = _repositryLocalScheme.Session.CallFunction<SalitasCunaDto>("PR_OBTENER_SALITAS_BENEF(?,?,?,?)")
                                .SetParameter(0, query.SalaCunaId)
                                .SetParameter(1, query.SeleccionBaja)
                                .SetParameter(2, -1)
                                .SetParameter(3, -1)
                               ; 
                queryResult.SalitasCunaDto = (List<SalitasCunaDto>)querySession.List<SalitasCunaDto>();
            }
            return queryResult;
        }
    
    }
}
