using GAP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Entidad : ElementBase
    {
        public virtual string RazonSocial { get; set; }
        public virtual string NombreFantasia { get; set; }
        public virtual DateTime? FechaAlta { get; set; }
        public virtual string Cuit { get; set; }
        [NoCAPS]
        public virtual string FormaJuridicaId { get; set; }
        public virtual Sede Sede { get; set; }
        public virtual Responsable Responsable { get; set; }
        public virtual string Mail { get; set; }
        public virtual bool CertificadoFiscal { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string CodArea { get; set; } 
        public virtual string CbuBancaria { get; set; }
        public virtual string NumeroDeCuentaBancaria { get; set; }
        [NoCAPS]
        public virtual string EntidadBancariaId { get; set; }
        [NoCAPS]
        public virtual string SucursalId { get; set; }
        [NoCAPS]
        public virtual string NumeroID { get; set; }
        // public virtual string NombreSede { get; set; }
        // public virtual int DomicilioId { get; set; }
        // public virtual string Descripcion { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
