using GAP.Base.Dto.AdministrarConvenios;
using GAP.Base.Dto.AdministrarRequisitos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.SalasCuna
{
    public class SalasCunaReporteDto
    {
        public Int64 SalaCunaId { get; set; }
        public string NombreEntidad { get; set; }
        public string NombreSalasCuna { get; set; }
        public string EstadoSalasCuna { get; set; }
        public string Requisitos { get; set; }
        public string RequisitosEstado { get; set; }
        public List<ConveniosDeSalasCunaDto> Convenios { get; set; }
        public string ConveniosString { get; set; }
        public string ConveniosEstado { get; set; }
        public List<InmuebleDto> Inmuebles { get; set; }
        public DateTime? FechaAltaDefinitivaSalasCuna { get; set; }
        public DateTime? FechaInicioTramiteSalasCuna { get; set; }
        public string ResponsableSalasCuna { get; set; }
        public string MailSalaCuna { get; set; }
        public string TelefonoResponsableSalasCuna { get; set; }
        public string NroStickerSalasCuna { get; set; }
        public string DomicilioSalasCuna { get; set; }
        public string DebeRequisitos { get; set; }
        public string TieneConvenioActivo { get; set; }
        public Decimal GastosInfraestructura { get; set; }
        public Decimal CantidadSalitas { get; set; }
        public Decimal CantidadBeneficiarios { get; set; }
        public string NroExpedienteSalasCuna { get; set; }
        public List<RequisitosReporteSalaCunaDto> ListRequisitos { get; set; }
        public double MontoRefacciones { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; }
        public string EstadoCorrecto { get; set; }
        public string Codigo { get; set; }
        public string Zona { get; set; }
        public DateTime? FechaInauguracion { get; set; }
    }
}
