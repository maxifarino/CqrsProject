using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public abstract class IPersona
    {
       public string Nombre { get; set; }
       public string Apellido { get; set; }
       public int Cuit { get; set; }
       public Domicilio Domicilio { get; set; }
       public DateTime? FechaNacimiento { get; set; }
       public int NumeroDocumento { get; set; }
       public int EstadoCivilId { get; set; }
       public int SexoId { get; set; }
       public int TelefonoCelular { get; set; }
       public int TipoDocumentoId { get; set; }
       public int CodigoPais { get; set; }
              
    }
}
