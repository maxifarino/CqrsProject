using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Beneficiario
{
    public class BeneficiarioReporteDto
    {
        #region RCIVIL
        public Int64 BeneficiarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroDocumento { get; set; }
        public string NombreSexo { get; set; }
        public string PaisNacionalidad { get; set; }
        public string PaisOrigen { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Domicilio { get; set; }
        #endregion

        #region INSCRIPCION BENEFICIARIO
        public DateTime? FechaInscripcion { get; set; }
        public DateTime? FechaFinInscripcion { get; set; }
        public string MotivoBaja { get; set; }
        #endregion

        #region SALA CUNA
        public string NombreSalaCuna { get; set; }
        public string CodigoSalaCuna { get; set; }
        public string Turno { get; set; }
        #endregion

        #region PERSONA JURIDICA
        public string NombrePersonaJuridica { get; set; }
        #endregion

        #region DATOS EXTRA
        public string AsistioGuarderia { get; set; }
        public string NombreGuarderia { get; set; }
        public string EsAlergico { get; set; }
        public string DetalleAlergico { get; set; }
        public string TomaMedicamentos { get; set; }
        public string DetalleMedicamento { get; set; }
        public string TieneObraSocial { get; set; }
        public string DetalleObraSocial { get; set; }
        public string CondicionParticular { get; set; }
        public string DetalleCondicionParticular { get; set; }
        public string NombreGrupoSanguineo { get; set; }
        public string InstitucionMedica { get; set; }
        public DateTime? FechaUltimoControl { get; set; }
        public double Peso { get; set; }
        public double Talla { get; set; }
        public string PadeceEnfermedad { get; set; }
        #endregion

        #region DATOS MADRE

        public string NombreMadre { get; set; }
        public string ApellidoMadre { get; set; }
        public string NroDocumentoMadre { get; set; }
        public string NombreSexoMadre { get; set; }
        public string PaisNacionalidadMadre { get; set; }
        public string PaisOrigenMadre { get; set; }
        public DateTime? FechaNacimientoMadre { get; set; }
        public string DepartamentoMadre { get; set; }
        public string LocalidadMadre { get; set; }
        public string BarrioMadre { get; set; }
        public string DomicilioMadre { get; set; }
        public string EstadoCivilMadre { get; set; }


        //Características

        public string TieneObraSocialMadre { get; set; }
        public string DetalleObraSocialMadre { get; set; }
        public string DetalleCoberturaMedicaMadre { get; set; }
        public string NivelEscolaridadMadre { get; set; }
        public string OcupacionMadre { get; set; }
        public string ProgramaSocialMadre { get; set; }
        public string HorarioOcupacionMadre { get; set; }

        #endregion

        public Decimal? Contador { get; set; }
        public string AsisteSala { get; set; }
        public Int64 IdLeche { get; set; }
        public Int64 IdPanial { get; set; }
        public Int64 IdMotivoEspecial { get; set; }
        public string CasoEspecial { get; set; }
        public string Leche { get; set; }
        public string Panial { get; set; }
        public string MotivoEspecial { get; set; }
        public string CodigoAreaCelularInt { get; set; }
        public string TelefonoCelularInt { get; set; }
        public string CodigoAreaFijoInt { get; set; }
        public string TelefonoFijoInt { get; set; }
        public string RecibeProg { get; set; }
        public string OtrosProg { get; set; }

    }
}
