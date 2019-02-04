using GAP.Base.Dto;
using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
   public class CantidadBeneficiariosPorSalaQueryHandler: IQueryHandler<CantidadBeneficiariosPorSalaQuery, CantidadBeneficiariosPorSalaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public CantidadBeneficiariosPorSalaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public CantidadBeneficiariosPorSalaQueryResult Retrieve(CantidadBeneficiariosPorSalaQuery query)
        {
            Int64 cero = 0;
            
            var queryResult = new CantidadBeneficiariosPorSalaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<ContadorDto>("PR_REPORTE_BENEFICIARIOS_COUNT (?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

            .SetParameter(0, query.FechaDesde)
            .SetParameter(1, query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : query.FechaHasta)
            .SetParameter(2, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
            .SetParameter(3, query.SalaCunaId != null ? query.SalaCunaId : -1)
            .SetParameter(4, query.Codigo != null ? query.Codigo : "")
            .SetParameter(5, query.NroDocumento)
            .SetParameter(6, query.DadosBaja ? 'S' : 'N')
            .SetParameter(7, query.DepartamentoId != cero ? query.DepartamentoId : -1)
            .SetParameter(8, query.LocalidadId != cero ? query.LocalidadId : -1)
            .SetParameter(9, query.BarrioId != cero ? query.BarrioId : -1)
            .SetParameter(10, query.SituacionCritica)
            .SetParameter(11, query.TipoBeneficiario != null ? query.TipoBeneficiario : "0")
            .SetParameter(12, query.TipoDocumentoId)
            .SetParameter(13, -1);          

            ContadorDto contador = (ContadorDto)querySession.UniqueResult();

            if (contador.Contador != 0)
            {

                queryResult.cantidad = contador.Contador;

            }

            return queryResult;
        }
    }
}
