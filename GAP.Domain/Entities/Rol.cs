using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Rol : ElementBase
    {
        public virtual string Nombre { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
