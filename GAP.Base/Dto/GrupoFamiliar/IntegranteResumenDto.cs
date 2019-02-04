using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.GrupoFamiliar
{
    public class IntegranteResumenDto
    {
        public Int64 IdIntegrante { get; set; }
        public Int64 NumeroId { get; set; }
        public string CodigoPais { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string VinculoId { get; set; }
        public string VinculoNombre { get; set; }
        public string SexoId { get; set; }
        public string EsTutor { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
