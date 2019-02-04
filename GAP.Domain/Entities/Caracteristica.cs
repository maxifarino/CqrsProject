using GAP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Caracteristica : ElementBase
    {
        [NoCAPS]
        public string IdTipoCaracteristica { get; set; }
        [NoCAPS]
        public string IdCaracteristica { get; set; }
        public int Accion { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
