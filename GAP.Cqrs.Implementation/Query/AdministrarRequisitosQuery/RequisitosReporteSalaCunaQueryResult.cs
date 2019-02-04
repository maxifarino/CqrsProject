using GAP.Base.Dto.AdministrarRequisitos;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos
{
    public class RequisitosReporteSalaCunaQueryResult : IQueryResult
    {
        public List<RequisitosReporteSalaCunaDto> RequisitosPresentadosDto { get; set; }
    }
}
