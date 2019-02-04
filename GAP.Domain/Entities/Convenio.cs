using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Convenio : ElementBase
    {
        public virtual int Id { get; set; }
        public virtual int SalaCunaId { get; set; }
        public virtual DateTime? FechaDesde { get; set; }
        public virtual DateTime? FechaHasta { get; set; }
        public virtual Decimal? Monto { get; set; }
        public virtual String Observacion { get; set; } 

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
