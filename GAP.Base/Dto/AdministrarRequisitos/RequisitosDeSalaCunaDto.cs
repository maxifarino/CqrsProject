using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.AdministrarRequisitos
{
    public class RequisitosDeSalaCunaDto
    {

        //private bool estadoRequisito;

        public Decimal? IdRequisito { get; set; }
        public string NombreRequisito { get; set; }
        public string EstadoRequisito { get; set; }

        public bool Estado
        {
            get
            {
                return (EstadoRequisito.Equals("S"));
            }
        }


        public DateTime? FechaPresentacion { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
        public string Observaciones { get; set; }
        public Decimal IdSalaCuna { get; set; }  
    }
}
