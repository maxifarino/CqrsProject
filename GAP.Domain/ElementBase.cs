using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain
{
    public abstract class ElementBase : EntityBase
    {
        public abstract void Accept(VisitorBase visitor);
    }
}
