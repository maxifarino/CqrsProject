using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Usuario : ElementBase
    {
        public virtual int IdUsuario { get; set; }
        public virtual string Cuil { get; set; }
        public virtual int? rol { get; set; }
        public virtual int idRol { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
                visitor.Visit(this);
        }

    }
}
