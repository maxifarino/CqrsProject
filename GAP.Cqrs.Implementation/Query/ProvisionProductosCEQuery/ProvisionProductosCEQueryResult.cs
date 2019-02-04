using GAP.Base.Dto;
using GAP.Base.Dto.ProvisionProductos;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProvisionProductosCEQuery
{
    public class ProvisionProductosCEQueryResult : IQueryResult
    {
        public List<ProvisionProductosReporteDto> Provisiones { get; set; }
        public List<ProvisionProductosReporteDto> ProvisionesCE { get; set; }
        public ProvisionProductosSumarizadoDto ProvisionesSumarizado { get; set; }
        public DomicilioDto Domicilio { get; set; }
    }
}
