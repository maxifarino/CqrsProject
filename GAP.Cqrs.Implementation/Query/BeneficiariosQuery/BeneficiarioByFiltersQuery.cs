using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioByFiltersQuery : QueryFilter
    {
        public int SalitaCunaId { get; set; }
        public int BeneficiarioId { get; set; }
        public bool DadoBaja { get; set; }
        public bool Especial { get; set; }

    
     
    }
}
