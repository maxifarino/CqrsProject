using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Inscripcion: ElementBase
    {
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaFinInscripcion { get; set; }
        public int SalitaId { get; set; }
        public string Descripcion { get; set; }
        public int BeneficiarioId { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
