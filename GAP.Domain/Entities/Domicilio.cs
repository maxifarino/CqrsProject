using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Domicilio : ElementBase
    {
        public virtual int? LocalidadId { get; set; }
        public virtual int? DepartamentoId { get; set; }
        public virtual int? BarrioId { get; set; }
        public virtual int? TipoCalleId { get; set; }
        public virtual int? CalleId { get; set; }
        public virtual string Direccion { get; set; }
        public virtual int Altura { get; set; }
        public virtual string Piso { get; set; }
        public virtual string Departamento { get; set; }
        public virtual string Torre { get; set; }
        public virtual string Longitud { get; set; }
        public virtual string Latitud { get; set; }
        public virtual string Manzana { get; set; }
        public virtual string Parcela{get;set;}
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
