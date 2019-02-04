using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.GrupoFamiliar
{
    public class TutorBeneficiarioVerDto
    {
        public string NombreSexo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ObraSocial { get; set; }
        public bool? TieneObraSocial { get; set; }
        public string Ocupacion { get; set; }
        public string CoberturaMedica { get; set; }   
        public string NivelAlcanzado { get; set; }
        public string ProgramaSocial { get; set; }
        public bool? TienePrograma { get { return ProgramaSocial != null ? ProgramaSocial.Equals("S") : false; } }
        public string HorarioOcupacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nacionalidad { get; set; }
        public string PaisOrigen { get; set; }
        public string DepartamentoOrigen { get; set; }
        public string ProvinciaOrigen { get; set; }
        public string LocalidadOrigen { get; set; }
        public string Domicilio { get; set; }
        public string CodigoAreaCelurar { get; set; }
        public string TelefonoCelular { get; set; }
        public string CodigoAreaFijo { get; set; }
        public string TelefonoFijo { get; set; }
        public string Existe { get; set; }
        public string RecibeProgramaLeche { get; set; }
        public string NombreProgramaLeche { get; set; }
 


    }
}
