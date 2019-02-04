using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.IVisitor
{
   public abstract class IVisitorSocioAmbiental : VisitorBase
    {
       public abstract void Visit(SocioAmbiental socioAmbiental);
    }
}
