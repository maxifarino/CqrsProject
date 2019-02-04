using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class BeneficiarioSADto
    {
        public Decimal? IdSocioAmbiental { get; set; }
        public Decimal? IdTipoSocioAmbiental  { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NombreSexo { get; set; }
        public string ObraSocial { get; set; }
        public string Turno { get; set; }
        public string TieneAsigUnivHijo { get; set; }
        public string Domicilio { get; set; }
        public string NumeroTelefono { get; set; }
        public string SalaCuna { get; set; }
        public int Edad { get; set; }
        public string TipoEdad { get; set; }


    }
}
