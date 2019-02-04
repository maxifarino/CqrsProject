using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.AdministrarSalasCuna
{
    public class AdministrarSalasCunaDto
    {
        public Decimal Indocumentados { get; set; }
        public Decimal Beneficiarios { get; set; }
        public string EstadoConvenio { get; set; }
        public bool Convenio { get { return (EstadoConvenio.Equals("S")); } }
        public string EstadoRequisitos { get; set; }
        public string AltaDefinitiva { get; set; }
        public bool FaltanRequisitos { get { return EstadoRequisitos.Equals("S"); } }
        public bool Definitiva { get { return AltaDefinitiva.Equals("S"); } }
    }
}
