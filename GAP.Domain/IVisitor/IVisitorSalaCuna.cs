using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.IVisitor
{
    public abstract class IVisitorSalaCuna : VisitorBase
    {
        public abstract void Visit(SalaCuna salaCuna);
    }
}
