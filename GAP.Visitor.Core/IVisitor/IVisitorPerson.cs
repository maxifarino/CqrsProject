using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Core.IVisitor
{
    public abstract class IVisitorPerson : VisitorBase 
    {
        public abstract void Visit(Person person);
    }
}
