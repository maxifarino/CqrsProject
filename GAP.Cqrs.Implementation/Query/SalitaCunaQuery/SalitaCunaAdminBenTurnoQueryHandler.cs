using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Mock;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalitaCunaQuery
{
    public class SalitaCunaAdminBenTurnoQueryHandler: IQueryHandler <SalitaCunaAdminBenTurnoQuery, SalitaCunaAdminBenTurnoQueryResult>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public SalitaCunaAdminBenTurnoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public SalitaCunaAdminBenTurnoQueryResult Retrieve(SalitaCunaAdminBenTurnoQuery query)
        {
            var queryResult = new SalitaCunaAdminBenTurnoQueryResult();

            if (GlobalVars.MockedMode)
            {
                SalitaCunaDtoMocked salasMocked = SalitaCunaDtoMocked.GetInstance();
                queryResult.SalitasCunaDto = salasMocked.GetMocked();
            }
            else
            {

                var querySession = _repositryLocalScheme.Session.CallFunction<SalitasCunaDto>("PR_OBTENER_SALITAS_SA(?,?,?,?,?)")
                                .SetParameter(0, query.SalaCunaId)
                                .SetParameter(1, query.SeleccionBaja)
                                .SetParameter(2, query.IncluirSegundoAnillo)
                                .SetParameter(3, -1)
                                .SetParameter(4, -1)
                               ; 
                queryResult.SalitasCunaDto = (List<SalitasCunaDto>)querySession.List<SalitasCunaDto>();
            }
            return queryResult;
        }
    
    }
}
