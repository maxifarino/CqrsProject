using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental
{
   public class VerSocioAmbientalByFiltersQuery:IQuery
    {
        public int BenefeciarioId { get; set; }
        public int TipoSocioAmbiental { get; set; }
    }
}
