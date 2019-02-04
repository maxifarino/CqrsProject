using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class PersonalAsistenciaDto
    {
        //Cargos - Cargos y NombreSalaCuna - NombresSalasCuna se repiten por motivos de base

        public Int64 PersonalId { get; set; }
        public string Turno { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Cargos { get; set; }
        public string Cargo { get; set; }
        public string Sexo { get; set; }
        public string NombresSalaCuna { get; set; }
        public string NombreSalaCuna { get; set; }
        public string Documento { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string ComentarioBaja { get; set; }
        public bool tieneAsistencia { get { return ((Asistencia == "S") ? true : false); } }
        public string Asistencia { get; set; }
        public bool EsPersonaConflictiva { get; set; }
        public Decimal IdClase { get; set; }
        public string NroDocumento { get; set; }
        public string CumplePorcentajeAsistencia { get; set; }
        public Decimal PorcentajeAsistencia { get; set; }
        public string DadosDeBaja { get; set; }
    }
}
