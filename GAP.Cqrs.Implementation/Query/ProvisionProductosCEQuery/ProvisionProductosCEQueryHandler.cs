using GAP.Base;
using GAP.Base.Dto.ProvisionProductos;
using GAP.Base.Mock;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProvisionProductosCEQuery
{
    public class ProvisionProductosCEQueryHandler : IQueryHandler<ProvisionProductosCEQuery, ProvisionProductosCEQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ProvisionProductosCEQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ProvisionProductosCEQueryResult Retrieve(ProvisionProductosCEQuery query)
        {
            var queryResult = new ProvisionProductosCEQueryResult();
            Int64 cero = 0;

            var querySession2 = _repositryLocalScheme.Session.CallFunction<ProvisionProductosReporteDto>("PR_REPORTE_PROVISIONES_CE (?,?,?,?,?,?,?,?,?,?,?,?)")

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

            queryResult.ProvisionesCE = (List<ProvisionProductosReporteDto>)querySession2.List<ProvisionProductosReporteDto>();
            return queryResult;
        }
    }
}
