using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class CantidadBeneficiariosPorSalaQueryResult : IQueryResult
    {
        public decimal? cantidad { get; set; }
    }
}
