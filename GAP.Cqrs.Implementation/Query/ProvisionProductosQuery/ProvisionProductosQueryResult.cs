using GAP.Base.Dto;
using GAP.Base.Dto.ProvisionProductos;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProvisionProductosQuery
{
    public class ProvisionProductosQueryResult : IQueryResult
    {
        public List<ProvisionProductosReporteDto> Provisiones { get; set; }
        public List<ProvisionProductosReporteDto> ProvisionesCE { get; set; }
        public ParametrosProvisionDto ParametrosProvision { get; set; }
        public ProvisionProductosSumarizadoDto ProvisionesSumarizado { get; set; }
        public DomicilioDto Domicilio { get; set; }
    }
}
