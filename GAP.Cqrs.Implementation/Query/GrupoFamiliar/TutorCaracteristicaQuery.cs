using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class TutorCaracteristicaQuery : IQuery
    {
        public string SexoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroId { get; set; }
        public string CodigoPais { get; set; }

        public string SexoIdBeneficiario { get; set; }
        public string NumeroDocumentoBeneficiario { get; set; }
        public string NumeroIdBeneficiario { get; set; }
        public string CodigoPaisBeneficiario { get; set; }

        public int BeneficiarioId { get; set; }

    }

}