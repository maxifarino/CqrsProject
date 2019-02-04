using GAP.Base.Dto.Beneficiario;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioReporteQuery : QueryFilter
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public Int64? PersonaJuridicaId { get; set; }
        public Int64? SalaCunaId { get; set; }
        public string NroDocumento { get; set; }
        public bool DadosBaja { get; set; }
        public bool RecibeOtroPS { get; set; }
        public Int64? DepartamentoId { get; set; }
        public Int64? LocalidadId { get; set; }
        public Int64? BarrioId { get; set; }
        public Int64 SituacionCritica { get; set; }
        public String Codigo { get; set; }
        public String TipoBeneficiario { get; set; }
        public String TipoDocumentoId { get; set; }
    }
}
