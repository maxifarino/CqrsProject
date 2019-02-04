using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Beneficiario
{
    public class BeneficiarioVerDto
    {
        public string NombreSexo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ObraSocial { get; set; }
        public bool? TieneObraSocial { get { return ObraSocial != null ? true : false; } }
        public string GrupoSanguineo { get; set; }
        public string NombreGuarderia { get; set; }
        public bool? AsistioGuarderia { get { return NombreGuarderia != null ? true : false; } }
        public string DetalleAlergico { get; set; }
        public bool? EsAlergico { get { return DetalleAlergico != null ? true : false; } }
        public string DetalleMedicamento { get; set; }
        public bool? TomaMedicamentos { get { return DetalleMedicamento != null ? true : false; } }
        public string CondicionParticular { get; set; }
        public bool? Circunstancia { get { return CondicionParticular != null ? CondicionParticular.Equals("S") : false; } }
        public string InstitucionMedica { get; set; }
        public DateTime? FechaUltimoControl { get; set; }
        public double Peso { get; set; }
        public double Talla { get; set; }
        public string Enfermedad { get; set; }
        public string Discapacidad { get; set; }
        public string TieneAsigUnivHijo { get; set; }
        public string SituacionCritica { get; set; }
        public string Sugerencias { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nacionalidad { get; set; }
        public string PaisOrigen { get; set; }
        public string DepartamentoOrigen { get; set; }
        public string ProvinciaOrigen { get; set; }
        public string LocalidadOrigen { get; set; }
        public string Domicilio { get; set; }
        public string LatitudString { get; set; }
        public string LongitudString { get; set; }
        public Double Latitud { get { return (String.IsNullOrEmpty(LatitudString) ? 0.0 : Double.Parse(LatitudString)); } }
        public Double Longitud { get { return (String.IsNullOrEmpty(LongitudString) ? 0.0 : Double.Parse(LongitudString)); } }
        public Decimal CantidadInscriptos { get; set; }
        public Decimal CantidadInscriptosCE { get; set; }
        public Decimal CantidadInscriptosSA { get; set; }
        public Decimal CantidadInscriptosBenef { get; set; }

        public string AsisteSala { get; set; }
        public Int64 IdLeche { get; set; }
        public Int64 IdPanial { get; set; }
        public Int64 IdMotivoEspecial { get; set; }
        public string CasoEspecial { get; set; }
        public DateTime FechaDesdeInscripcion { get; set; }
        public string Programa { get; set; }
        public string NombrePrograma { get; set; }

    }
}
