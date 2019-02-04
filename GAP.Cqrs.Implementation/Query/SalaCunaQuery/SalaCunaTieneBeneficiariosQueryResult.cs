using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalaCunaTieneBeneficiariosQueryResult : IQueryResult
    {
        public string CantidadBeneficiariosActivos { get; set; }

        public string CantidadPersonalAsignadoCurso { get; set; }
    }
}
