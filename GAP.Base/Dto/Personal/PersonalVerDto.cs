using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Personal
{
    public class PersonalVerDto
    {
        public string NombreSexo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nacionalidad { get; set; }
        public string PaisOrigen { get; set; }
        public string DepartamentoOrigen { get; set; }
        public string ProvinciaOrigen { get; set; }
        public string LocalidadOrigen { get; set; }
        public string Domicilio { get; set; }
        public string ComentarioBaja { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string PersonaConflictiva { get; set; }
        public string Cargo { get; set; }
        public string TurnoSalita { get; set; }
    }
}
