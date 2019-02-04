using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioYTutorCaracteristicasQueryResult : IQueryResult
    {
        public BeneficiarioYTutorCaracteristicasDto BeneficiarioYTutorCaracteristicas { get; set; }
    }
}
