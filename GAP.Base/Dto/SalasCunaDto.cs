using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class SalasCunaDto
    {
        public string Codigo { get; set; }
        public string EstadoSalaCuna { get; set; }
        public string DadoDeBaja { get; set; }
        public string SalaDefinitiva { get; set; }
        public string RazonSocial { get; set; }
        public string NombreSalaCuna { get; set; }
        public string Cuit { get; set; }
        public Int64? Id { get; set; }
        public bool? Activa { get { return DadoDeBaja != null ? DadoDeBaja.Equals("N") : false; } }
        public bool? Definitiva { get { return SalaDefinitiva != null ? SalaDefinitiva.Equals("S") : false; } }
        public DateTime? FechaInauguracion { get; set; }
        public DateTime? FechaInicioTramite { get; set; }
        public string IdZona { get; set; } 

    }
}
