using GAP.Base.Dto.AdministrarRequisitos;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos
{
    public class RequisitosDeSalaCunaQueryResult : IQueryResult
    {
        public List<RequisitosDeSalaCunaDto> RequisitosDeSalaCunaDto { get; set; }
    }
}
