using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class InmuebleDto
    {
        public Int64 Id { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public DateTime? FechaRealizacion { get; set; }
    }
}
