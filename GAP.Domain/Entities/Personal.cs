using GAP.Base;
using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Personal : ElementBase
    {
        public virtual BeneficiarioPersona PersonaSeleccionada { get; set; }
        public virtual DateTime? FechaAsignacion{ get; set; }
        public virtual DateTime? FechaInscripcion { get; set; }
        public virtual string DescripcionLarga { get; set; }
        public virtual int? IdCargo { get; set; }
        public virtual int? IdDomicilio { get; set; }
        public virtual int IdAsignacionPersonal { get; set; }
        public virtual int? SalitaID { get; set; }
        public virtual int? SalaCunaId { get; set; }
        public virtual int? CursoId { get; set; }
        public virtual bool Obligatorio { get; set; }
        [NoCAPS]
        public virtual string PaisOrigenId { get; set; }
        [NoCAPS]
        public virtual string ProvinciaOrigenId { get; set; }
        [NoCAPS]
        public virtual string DepartamentoOrigenId { get; set; }
        [NoCAPS]
        public virtual string LocalidadOrigenId { get; set; }
        [NoCAPS]
        public virtual string NacionalidadId { get; set; }
        [NoCAPS]
        public virtual bool PersonId { get; set; }
        public virtual Domicilio Domicilio { get; set; }

        public virtual List<RequisitoPersonal> requisitos { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
