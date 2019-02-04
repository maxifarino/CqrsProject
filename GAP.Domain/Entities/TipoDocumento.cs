using GAP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class TipoDocumento :ElementBase
    {
        [NoCAPS]
        public virtual string TipoDocumentoId { get; set; }
        [NoCAPS]
        public virtual string PaisTipoDocumentoId { get; set; }
        [NoCAPS]
        public virtual string OrganismoEmisorId { get; set; }
        [NoCAPS]
        public override void Accept(IVisitor.VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
