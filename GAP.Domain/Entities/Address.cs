using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Address : ElementBase
    {
        public string City { get; set; }
        public string Country { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
