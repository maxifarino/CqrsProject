using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.MadresBeneficiariosQuery
{
    public class MadresBeneficiariosQueryHandler : IQueryHandler<MadresBeneficiariosQuery, MadresBeneficiariosQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public MadresBeneficiariosQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public MadresBeneficiariosQueryResults Retrieve(MadresBeneficiariosQuery query)
        {
            var queryResult = new MadresBeneficiariosQueryResults();
            var querySession = _repositryLocalScheme.Session.CallFunction<MadresBeneficiariosDto>("PR_REPORTE_MADRES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

                .SetParameter(0, query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1)
                .SetParameter(1, query.SalaCunaId != null ? query.SalaCunaId.Value : -1)
                .SetParameter(2, query.Codigo)
                .SetParameter(3, query.DepartamentoId != null ? query.DepartamentoId.Value : -1)
                .SetParameter(4, query.LocalidadId != null ? query.LocalidadId.Value : -1)
                .SetParameter(5, query.BarrioId != null ? query.BarrioId.Value : -1)
                .SetParameter(6, query.Ubicacion)
                .SetParameter(7, query.EdadDesde != null ? query.EdadDesde.Value : -1)
                .SetParameter(8, query.EdadHasta != null ? query.EdadHasta.Value : -1)
                .SetParameter(9, query.NivelEscolaridad)
                .SetParameter(10, query.EstadoCivil)
                .SetParameter(11, query.Ocupacion)
                .SetParameter(12, query.Responsable)
                .SetParameter(13, 2);

            queryResult.MadresBeneficiarios = (List<MadresBeneficiariosDto>)querySession.List<MadresBeneficiariosDto>();

            return queryResult;
        }
    }
}
