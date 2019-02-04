using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.ProvisionProductos;
using GAP.Base.Mock;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProvisionProductosQuery
{
    public class ProvisionProductosQueryHandler : IQueryHandler<ProvisionProductosQuery, ProvisionProductosQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ProvisionProductosQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ProvisionProductosQueryResult Retrieve(ProvisionProductosQuery query)
        {
            var queryResult = new ProvisionProductosQueryResult();

            if (GlobalVars.MockedMode)
            {
                ProvisionProductosReporteDtoMocked provisionesMocked = ProvisionProductosReporteDtoMocked.GetInstance();
                queryResult.Provisiones = provisionesMocked.GetReporteMocked();
            }
            else
            {
                Int64 cero = 0;
                var querySession = _repositryLocalScheme.Session.CallFunction<ProvisionProductosReporteDto>("PR_REPORTE_PROVISIONES (?,?,?,?,?,?,?,?,?,?,?,?)")

                .SetParameter(0, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
                .SetParameter(1, query.SalaCunaId != null ? query.SalaCunaId : -1)
                .SetParameter(2, query.Codigo)
                .SetParameter(3, query.DiaDeCorte != null ? query.DiaDeCorte : -1)
                .SetParameter(4, query.Mes != null ? query.Mes : -1)
                .SetParameter(5, query.Anio != null ? query.Anio : -1)
                .SetParameter(6, query.Ubicacion == 0 ? 1 : query.Ubicacion)
                .SetParameter(7, query.DepartamentoId != cero ? query.DepartamentoId : -1)
                .SetParameter(8, query.LocalidadId != cero ? query.LocalidadId : -1)
                .SetParameter(9, query.BarrioId != cero ? query.BarrioId : -1)
                .SetParameter(10, query.EdadMaxima != null ? query.EdadMaxima : -1)
                .SetParameter(11, -1);

                queryResult.Provisiones = (List<ProvisionProductosReporteDto>)querySession.List<ProvisionProductosReporteDto>();
            }

            var querySession2 = _repositryLocalScheme.Session.CallFunction<ParametrosProvisionDto>("PR_PARAMETROS_PROVISIONES ()");
            queryResult.ParametrosProvision = querySession2.UniqueResult<ParametrosProvisionDto>();
            //Valores que en un futura seran parametros fijos.

            float paramLecheA = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramLecheA.ToString());
            float paramLecheB = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramLecheB.ToString());
            float paramPanialA = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramPanialA.ToString());
            float paramPanial0a2Anios = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramPanial0a2Anios.ToString());
            float paramPanial3Anios = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramPanial3Anios.ToString());

            foreach (ProvisionProductosReporteDto provisionesPorEntidadYSala in queryResult.Provisiones)
                provisionesPorEntidadYSala.SetParametrosDeCalculo(paramLecheA, paramLecheB, paramPanialA, paramPanial0a2Anios, paramPanial3Anios);

            return queryResult;
        }
    }
}
