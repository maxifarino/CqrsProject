using GAP.Base.Dto;
using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.Beneficiario
{
    public class BeneficiarioByFiltersQueryResult : IQueryResult
    {        
        public List<BeneficiarioDto> Beneficiarios { get; set; }
    }
}
