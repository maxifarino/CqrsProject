using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
  public class RequisitoPersonal : ElementBase
    {
      public virtual bool? Estado { get; set; }
      public virtual bool Baja { get; set; }

      public virtual int? IdRequisitoPersonal { get; set; }
      public virtual DateTime? fechaPresentacion { get; set; }

      public override void Accept(VisitorBase visitor)
      {
          visitor.Visit(this);
      }

    }
}
