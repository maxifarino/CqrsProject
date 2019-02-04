using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Personal
{
    public class PersonalListadoDto
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Decimal ClaseNumero { get; set; }
        public DateTime? FechaClase { get; set; }
        public string Asistio { get; set; }
    }
}
