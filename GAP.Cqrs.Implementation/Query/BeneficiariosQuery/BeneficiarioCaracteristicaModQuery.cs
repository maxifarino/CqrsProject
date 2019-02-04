using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioCaracteristicaModQuery : IQuery
    {
        public string SexoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroId { get; set; }
        public string CodigoPais { get; set; }

        public int NumeroSalita { get; set; }

    }

}
