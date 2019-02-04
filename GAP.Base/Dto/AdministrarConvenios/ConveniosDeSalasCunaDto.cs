using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.AdministrarConvenios
{
    public class ConveniosDeSalasCunaDto
    {
        public Int64? Id { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public double? Monto { get; set; }
        public String Observacion { get; set; }  
    }
}
