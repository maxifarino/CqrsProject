using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;


namespace GAP.Cqrs.Implementation.Query.SalitaCunaQuery
{
    public class GrupoEtarioByFiltersQueryResults : IQueryResult 
    {
        public List<GrupoEtarioDto> listGrupoEtario { get; set; }
    }
}
