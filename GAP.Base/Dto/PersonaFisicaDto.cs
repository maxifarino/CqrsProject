using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class PersonaFisicaDto
    {
        /*public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Sexo { get; set; }*/

        public Int64 NumeroId { get; set; }
        public Int64? IdUsuario { get; set; }
        public string CodigoPais { get; set; }
        public string NumeroDocumento { get; set; }
        public string SexoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }

    }
}
