using GAP.Base.Dto.AdministrarSalasCuna;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.AdministrarSalasCunaQueryResult
{
    public class AdministrarSalasCunaByFiltersQueryResult : IQueryResult
    {
        public AdministrarSalasCunaDto AdministrarSalasCunaDto { get; set; }
    }
}
