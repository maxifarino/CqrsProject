using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarSalaCunaQuery
{
    public class AdministrarSalasCunaByFiltersQuery : IQuery
    {
        public Int64 IdSalaCuna { get; set; }
    }
}
