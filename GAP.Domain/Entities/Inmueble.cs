using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Inmueble : ElementBase
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public double? Monto { get; set; }
        public DateTime? FechaRealizacion { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            visitor.Visit(this);
        }
        public int SalaCunaId { get; set; }
    }
}
