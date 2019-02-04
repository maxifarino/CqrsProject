using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class CantidadBeneficiariosPorSalaQuery : IQuery
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public Int64? PersonaJuridicaId { get; set; }
        public Int64? SalaCunaId { get; set; }
        public Int64? NroDocumento { get; set; }
        public bool DadosBaja { get; set; }
        public Int64? DepartamentoId { get; set; }
        public Int64? LocalidadId { get; set; }
        public Int64? BarrioId { get; set; }
        public Int64 SituacionCritica { get; set; }
        public string Codigo { get; set; }
        public string TipoBeneficiario { get; set; }
        public string TipoDocumentoId { get; set; }
        public bool RecibeOtroPS { get; set; }
    }
}
