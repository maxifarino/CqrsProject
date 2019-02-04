using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
   public class EnfermedadIntegrante: ElementBase
    {
        public virtual bool NecesitaAtencion { get; set; }
        public virtual bool RecibeAtencion { get; set; }
        public virtual bool TieneCertificadoDiscapacidad { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
