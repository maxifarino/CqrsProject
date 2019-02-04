using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioConsultaReporteQueryResult : IQueryResult
    {
        public List<BeneficiarioReporteDto> Beneficiarios { get; set; }
    }
}
