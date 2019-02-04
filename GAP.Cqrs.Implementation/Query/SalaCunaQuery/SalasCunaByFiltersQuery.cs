using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query
{
    public class SalasCunaByFiltersQuery : QueryFilter
    {
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string NombreFantasia { get; set; }
        public string NombreSalaCuna { get; set; }
        public int? EstadoId { get; set; }
        public string Codigo { get; set; }

    }
}
