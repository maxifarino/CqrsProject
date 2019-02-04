using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Curso : ElementBase
    {
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int? CantDias { get; set; }
        public virtual double? HorasPorDia { get; set; }
        public virtual string IdZona { get; set; }

        public virtual int? Porcentaje { get; set; }
        public virtual string Ente { get; set; }
        public virtual string Cargos { get; set; }
        public virtual string Salas { get; set; }
        public virtual DateTime? FechaAlta { get; set; }
        public virtual DateTime? FechaInicio { get; set; }
        public virtual DateTime? FechaFin { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }       
        
        
    }
}
