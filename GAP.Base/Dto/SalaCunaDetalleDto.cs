using GAP.Base.Dto.AdministrarConvenios;
using GAP.Base.Dto.AdministrarRequisitos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class SalaCunaDetalleDto
    {
        #region Sala cuna
        public Int64 Id { get; set; }
        public string NombreSalaCuna { get; set; }
        public Decimal DomicilioId { get; set; }
        public DateTime? FechaInicioTramiteSalaCuna { get; set; }
        public DateTime? FechaAltaDefinitiva { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; }
        public string EstadoSalaCuna { get; set; }
        public string Domicilio { get; set; }
        public string LatitudString { get; set; }
        public string LongitudString { get; set; }
        public Double Latitud { get { return (String.IsNullOrEmpty(LatitudString) ? 0.0 : Double.Parse(LatitudString)); } }
        public Double Longitud { get { return (String.IsNullOrEmpty(LongitudString)? 0.0 : Double.Parse(LongitudString)); } }
        public string Responsable { get; set; }
        public string MailResponsable { get; set; }
        public string TelefonoResponsable { get; set; }
        public string NumeroSticker { get; set; }
        public string NumeroExpediente { get; set; }
        public string Capital { get; set; }//para mapear contra la base
        public bool EsZonaCapital { get { return !string.IsNullOrEmpty(Capital) && Capital.Equals("S"); } } //para mostrar en interfaz web
        public string Torre { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        #endregion
        #region Entidad
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuit { get; set; }
        public string SedeId { get; set; }
        #endregion
        public List<RequisitosDeSalaCunaDto> Requisitos { get; set; }
        public List<InmuebleDto> Inmuebles { get; set; }
        public List<ConveniosDeSalasCunaDto> Convenios { get; set; }
        public List<SalitasCunaDto> Salitas { get; set; }
        public string CbuBancaria { get; set; }
        public string SucursalId { get; set; }
        public string NumeroDeCuentaBancaria { get; set; }
        public string EntidadBancariaId { get; set; }
        public string Codigo { get; set; }
        public DateTime? FechaInauguracion { get; set; }
    }
}
