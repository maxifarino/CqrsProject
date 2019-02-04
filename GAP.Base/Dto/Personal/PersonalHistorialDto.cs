using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Personal
{
    public class PersonalHistorialDto
    {
        public string NombreSalaCuna { get; set; }
        public string TurnoSalita { get; set; }
        public string Cargo { get; set; }
        public int IdRequisitoEmpelado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaBaja{ get; set; }
        public string MotivoBaja { get; set; }
        public string PersonaConflictiva { get; set; }
    }
}
