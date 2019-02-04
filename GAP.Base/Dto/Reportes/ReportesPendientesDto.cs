using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Reportes
{
    public class ReportesPendientesDto
    {
        public Int64 ProcesoId { get; set; }
        public string NombreProceso { get; set; }
        public string StringProcedimiento { get; set; }
        public string Cuil { get; set; } 
    }
}
