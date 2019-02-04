using GAP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class SalaCuna : ElementBase
    {
        public string Nombre { get; set; }
        public DateTime? FechaAltaDefinitiva { get; set; }
        public DateTime? FechaInicioTramite { get; set; }
        [NoCAPS]
        public Responsable Responsable { get; set; }
        [NoCAPS]
        public Entidad Entidad { get; set; }
        public int Estado { get; set; }
        [NoCAPS]
        public DateTime? FechaUltimaModificacion { get; set; }
        [NoCAPS]
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; }
        public string NumeroSticker { get; set; }
        public string NumeroExpediente { get; set; }
        [NoCAPS]
        public UsuarioLog IdUsuarioUltimaModificacion { get; set; }
        public Domicilio Domicilio { get; set; }
        public bool? Capital { get; set; }
        public override void Accept(IVisitor.VisitorBase visitor)
        {
            visitor.Visit(this);
        }

        public string CbuBancaria { get; set; }

        public string SucursalId { get; set; }

        public string NumeroDeCuentaBancaria { get; set; }

        public string EntidadBancariaId { get; set; }

        public string Codigo { get; set; }
        public DateTime? FechaInauguracion { get; set; }
    }
}
