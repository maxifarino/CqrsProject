using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Sede:ElementBase
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public Domicilio Domicilio { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
