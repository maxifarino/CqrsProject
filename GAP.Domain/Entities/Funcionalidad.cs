using GAP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Funcionalidad : ElementBase
    {
        [NoCAPS]
        public virtual string Nombre { get; set; }
        [NoCAPS]
        public virtual string Path { get; set; }

        public virtual Funcionalidad Padre { get; set; }



        public override void Accept(IVisitor.VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
