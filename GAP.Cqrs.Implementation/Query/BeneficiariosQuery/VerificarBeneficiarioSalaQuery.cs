using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class VerificarBeneficiarioSalaQuery : IQuery
    {
        public int BeneficiarioId { get; set; }
    }
}
