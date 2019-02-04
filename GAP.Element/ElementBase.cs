using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Element
{
    public abstract class ElementBase
    {
        public abstract void Accept(VisitorBase visitor);
    }

}
