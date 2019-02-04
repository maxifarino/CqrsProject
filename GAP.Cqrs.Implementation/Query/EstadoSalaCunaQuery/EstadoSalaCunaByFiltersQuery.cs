using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.CqrsCore.Querys;

namespace GAP.Cqrs.Implementation.Query.EstadoSalaCunaQuery
{
   public class EstadoSalaCunaByFiltersQuery: IQuery
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
