using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Beneficiario
{
    public class BeneficiarioCaracteristicaDto
    {
        public string IdTieneObraSocial { get; set; }
        public string IdTipoTieneObraSocial { get; set; }
        public string IdObraSocial { get; set; }
        public string IdTipoObraSocial { get; set; }
        public string IdGrupoSanguineo { get; set; }
        public string IdTipoGrupoSanguineo { get; set; }
        public string IdEnfermedad { get; set; }
        public string IdTipoEnfermedad { get; set; }
        public string IdDiscapacidad { get; set; }
        public string IdTipoDiscapacidad { get; set; }
        public string AsignacionUniversalHijo { get; set; }
        public string AsistioGuarderia { get; set; }
        public string NombreGuarderia { get; set; }
        public string EsAlergico { get; set; }
        public string DetalleAlergico { get; set; }
        public string TomaMedicamentos { get; set; }
        public string DetalleMedicamento { get; set; }
        public string CondicionParticular { get; set; }
        public string InstitucionMedica { get; set; }
        public DateTime? FechaUltimoControl { get; set; }
        public double Peso { get; set; }
        public double Talla { get; set; }
        public string DetalleEnfermedad { get; set; }
        public string Sugerencias { get; set; }
        public string Observacion { get; set; }
        public string SituacionCritica { get; set; }
        public decimal DomicilioId { get; set; }
        public string AsisteSala { get; set; }
        public Int64? IdLeche { get; set; }
        public Int64? IdPanial { get; set; }
        public Int64? IdMotivoEspecial { get; set; }
        public string CasoEspecial { get; set; }
    }
}
