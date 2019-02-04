using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GAP.Domain.Entities
{
    public class Comunicacion: ElementBase   
    {
        public string Mail { get; set; }
        public string TelefonoAlternativo { get; set; }
        public string TelefonoCelular { get; set; }
        public string CodAreaCelular { get; set; }
        public string CodAreaAlternativo { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
