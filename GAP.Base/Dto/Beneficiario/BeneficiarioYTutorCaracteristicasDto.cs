using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Beneficiario
{
    public class BeneficiarioYTutorCaracteristicasDto
    {
        //Datos del beneficiario y tutor
        public string SexoIdBeneficiario { get; set; }
        public string NumeroDocumentoBeneficiario { get; set; }
        public double NumeroIdBeneficiario { get; set; }
        public string CodigoPaisBeneficiario { get; set; }
        public string NombreBeneficiario { get; set; }
        public string ApellidoBeneficiario { get; set; }
        public string SexoIdTutor { get; set; }
        public string NumeroDocumentoTutor { get; set; }
        public double NumeroIdTutor { get; set; }
        public string CodigoPaisTutor { get; set; }
        public string NombreTutor { get; set; }
        public string AsisteSala { get; set; }
        public string ApellidoTutor { get; set; }
        public Decimal IdDomicilioBeneficiario { get; set; }
        public Int64? IdPanial{ get; set; }
        public Int64? IdMotivoEspecial { get; set; }

        public string CasoEspecial { get; set; }
        
        // caracteristicas del beneficiario
        public string IdTieneObraSocial { get; set; }
        public string IdTipoTieneObraSocial { get; set; }
        public string IdObraSocial { get; set; }
        public string IdTipoObraSocial { get; set; }
        public string IdGrupoSanguineo { get; set; }
        public string IdTipoGrupoSanguineo { get; set; }
        public string AsistioGuarderia { get; set; }
        public string NombreGuarderia { get; set; }
        public string EsAlergico { get; set; }
        public string DetalleAlergico { get; set; }
        public string TomaMedicamentos { get; set; }
        public Int64? IdLeche { get; set; }
        public string DetalleMedicamento { get; set; }
        public string CondicionParticular { get; set; }
        public string InstitucionMedica { get; set; }
        public DateTime? FechaUltimoControl { get; set; }
        public double Peso { get; set; }
        public double Talla { get; set; }
        public string DetalleEnfermedad { get; set; }
        public string Sugerencias { get; set; }
        public string Observacion { get; set; }
        public string IdEnfermedad { get; set; }
        public string IdTipoEnfermedad { get; set; }
        public string IdDiscapacidad { get; set; }
        public string IdTipoDiscapacidad { get; set; }
        public string AsignacionUniversalHijo { get; set; }
        public string SituacionCritica { get; set; }
        public string Programa { get; set; }
        public string NombrePrograma { get; set; }



        // caracteristicas del tutor
        public string IdTieneObraSocialTutor { get; set; }
        public string IdTipoTieneObraSocialTutor { get; set; }
        public string IdCoberturaMedicaTutor { get; set; }
        public string IdObraSocialTutor { get; set; }
        public string IdTipoObraSocialTutor { get; set; }
        public string IdProgramaSocialTutor { get; set; }
        public string IdTipoProgamaSocialTutor { get; set; }
        public string ProgramaSocialTutor { get; set; }
        public string MultipleBeneficioSocialTutor { get; set; }
        public string IdMultipleBeneficioSocialTutor { get; set; }
        public string IdOcupacionTutor { get; set; }
        public string IdTipoOcupacionTutor { get; set; }
        public string IdNivelEscolaridadTutor { get; set; }
        public string IdTipoNivelEscolaridadTutor { get; set; }
        public string HorarioOcupacionTutor { get; set; }
        public string IdTipoCoberturaMedicaTutor { get; set; }
        public string CodigoAreaCelurar { get; set; }
        public string TelefonoCelular { get; set; }
        public string CodigoAreaFijo { get; set; }
        public string TelefonoFijo { get; set; }
    
    }
}
