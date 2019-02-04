using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Personal
{
    public class PersonalDto
    {
        public Int64 PersonalId { get; set; }
        public Int64 SalitaId { get; set; }
        public string Turno { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Sexo { get; set; }
        public string NombreSalaCuna { get; set; }
        public string Documento { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string ComentarioBaja { get; set; }
        public bool tieneAsistencia { get {return ((Asistencia == "S") ? true : false);} }
        public string Asistencia { get; set; }
        public bool EsPersonaConflictiva { get; set; }
        public Int64 IdAsignacionPersonal { get; set; }
        public string NroDocumento { get; set; }

    }
}
