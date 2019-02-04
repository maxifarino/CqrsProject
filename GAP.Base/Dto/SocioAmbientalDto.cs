using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class SocioAmbientalDto
    {
        public string CodigoSalaCuna { get; set; }
        public string OtraRedSostenFamiliar { get; set; }
        public string OtroProgControlMedico { get; set; }
        public string OtraInstitucion { get; set; }
        public Int64 SocioAmbientalId { get; set; }
        public Int64 NumeroSocioAmbiental { get; set; }
        public DateTime FechaEntrevista { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Profesional { get; set; }
        public int NiniosAsistenSC { get; set; }
        public string DetalleCredito { get; set; }
        public string ObserCrisis { get; set; }
        public string TieneDeuda { get; set; }
        public string TipoDeuda { get; set; }
        public string TipoViviendaId { get; set; }
        public string TipoViviendaIdTipo { get; set; }
        public string AccesoViviendaId { get; set; }
        public string AccesoViviendaIdTipo { get; set; }
        public string MuroId { get; set; }
        public string MuroIdTipo { get; set; }
        public string TarjetaCreditoIdTipo { get; set; }
        public string EntregaLeche { get; set; }
        public string TechoId { get; set; }
        public string TechoIdTipo { get; set; }
        public string PisoId { get; set; }
        public string PisoIdTipo { get; set; }
        public string EnergiaId { get; set; }
        public string EnergiaIdTipo { get; set; }
        public string TenenciaTerrenoId { get; set; }
        public string TenenciaTerrenoIdTipo { get; set; }
        public string TarjetaCreditoId { get; set; }
        public string BanioId { get; set; }
        public string BanioIdTipo { get; set; }
        public string UtilizaBanioId { get; set; }
        public Int16? CantidadHabitaciones { get; set; }
        public string AguaId { get; set; }
        public string AguaIdTipo { get; set; }
        public string CocinaId { get; set; }
        public string CoccionId { get; set; }
        public string CoccionIdTipo { get; set; }
        public string SituacionCrisisComent { get; set; }
        public string CursosRealizados { get; set; }
        public string GustosAprendizaje { get; set; }
        public Int64? LecheId { get; set; }
        public string LecheEspecial { get; set; }
        public Int64 ObtencionLecheId { get; set; }
        public string RecomiendaLeche { get; set; }
        public string InstitucionSalud { get; set; }
        public Int64 TipoFamiliaId { get; set; }
        public string Observaciones { get; set; }
        public List<GridSocioAmbientalDto> LstRedSosten { get; set; }
        public List<GridSocioAmbientalDto> LstAmbiente { get; set; }
        public List<GridSocioAmbientalDto> LstSituacionCrisis { get; set; }
        public List<GridSocioAmbientalDto> LstPrograma { get; set; }
        public List<TipoSocioAmbientalDto> LstTipoSocioAmbiental { get; set; }
        
        #region DatosReporte
        public string NombreSalaCuna { get; set; }
        public string NombreEntidad { get; set; }
        public string ApellidoBenef { get; set; }
        public string NombreBenef { get; set; }
        public string TipoSocioAmbiental { get; set; }
        public Int64? BeneficiarioId { get; set; }
        public string NumDocumentoBenef { get; set; }
        public DateTime? FechaNacimentoBenef{ get; set; }
        public DateTime? FecInscripcionDesde { get; set; }
        public DateTime? FecInscripcionHasta { get; set; }
        public string ProfesionalEntrevista { get; set; }
        public DateTime? FechaAltaSistema { get; set; }
        public string OtraRedSosten { get; set; }
        public string DeudaOCreditoAPagar { get; set; }
        public string EspecificacionCredito { get; set; }
        public int CantidadDormitorios { get; set; }
        public string DescripcionSituacionCrisis { get; set; }
        public string LeGustariaAprender { get; set; }
        public string SeRecomiendaEntregaLeche { get; set; }
        public string OtroProgramaControlMedico { get; set; }
        public string InstitucionProgramaMedico { get; set; }
        public string Sugerencia { get; set; }
        public string ObtencionLeche { get; set; }
        public string TiposFamiliarPadres { get; set; }
        public string NombreProducto { get; set; }
        public string UtilizacionBanio { get; set; }
        public string Cocina { get; set; }
        public string TipoVivienda { get; set; }
        public string TipoAcceso { get; set; }
        public string TipoMuro { get; set; }
        public string TipoTecho { get; set; }
        public string TipoPiso { get; set; }
        public string TipoBanio { get; set; }
        public string TipoEnergia { get; set; }
        public string TenenciaTerreno { get; set; }
        public string TipoAgua { get; set; }
        public string TipoCoccion { get; set; }
        public string TipoTarjeta { get; set; }
        public string RedSosten { get; set; }
        public string SituacionesCrisis { get; set; }
        public string ProgramaControlMedico { get; set; }
        public string Ambiente { get; set; }

        #endregion


    }
}
