using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class SalaCunaVerEntidadDto
    {
        public string Nombre { get; set; }
        public DateTime? FechaAltaDefinitiva { get; set; }
        public DateTime? FechaInicioTramite { get; set; }

        public string Estado { get; set; }
        public string Responsable { get; set; }


    }
}
