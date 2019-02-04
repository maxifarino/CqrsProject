using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto.AdministrarConvenios;


namespace GAP.Cqrs.Implementation.QueryResult.AdministrarConvenios
{
    public class ConveniosDeSalaCunaQueryResult : IQueryResult
    {

        public List<ConveniosDeSalasCunaDto> ConveniosDeSalaCunaDto { get; set; }

    }
}
