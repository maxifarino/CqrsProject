using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class DatosAdminBeneficiarioQuery : IQuery
    {
        public int SalaCunaId { get; set; }
        public int SeleccionBaja { get; set; }
    }
}
