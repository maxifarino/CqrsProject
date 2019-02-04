using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Requisito : ElementBase
    {
        public virtual bool Estado { get; set; }
        public virtual Int16? IdSalaCuna { get; set; }
        public virtual Int16? IdRequisito { get; set; }
        public virtual string EstadoRequisito { get; set; }
        public virtual DateTime? fechaPresentacion { get; set; }
        public virtual DateTime? fechaVigenciaHasta { get; set; }
        public virtual string Observaciones { get; set; }


        public override void Accept(IVisitor.VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
