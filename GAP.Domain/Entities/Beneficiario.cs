using GAP.Base;
using GAP.Base.Dto;
using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Beneficiario : ElementBase
    {
        public virtual double? Peso { get; set; }

        //Especial
        public virtual Int64? LecheEspecial { get; set; }
        public virtual Int64? PanialEspecial { get; set; }
        public virtual Int64? MotivoEspecial { get; set; }
        public virtual bool EsEspecial { get; set; }
        public virtual string AsisteSala { get; set; }


        //
        public virtual string NombrePrograma { get; set; }
        public virtual bool Programa { get; set; }
        public virtual int? Talla { get; set; }
        public virtual int TipoEnfermedad { get; set; }
        public virtual string InstitucionMedica { get; set; }
        public virtual string Observaciones { get; set; }
        public virtual DateTime? FechaUltimoControl { get; set; }
        public virtual bool EsAlergico { get; set; }
        public virtual string DetalleAlergia { get; set; }
        public virtual bool TomaMedicamentos { get; set; }
        public virtual string DetalleMedicamento { get; set; }
        public virtual bool CondicionParticular { get; set; }
        public virtual string DetalleCondicionParticular { get; set; }
        public virtual bool AsistioGuarderia { get; set; }
        public virtual string DetalleGuarderia { get; set; }
        public virtual bool TieneEnfermedad { get; set; }
        public virtual bool TieneDiscapacidad { get; set; }
        public virtual bool AsignacionUniversalHijo { get; set; }
        public virtual bool SituacionCritica { get; set; } 
        public virtual string DetalleEnfermedad { get; set; }
        public virtual List<Integrante> ListIntegrantes { get; set; }
        public virtual BeneficiarioPersona Caracteristica { get; set; }
        public virtual BeneficiarioPersona PersonaSeleccionada { get; set; }
        public virtual Inscripcion Inscripcion { get; set; }
        public virtual string Descripcion { get; set; }
        [NoCAPS]
        public virtual string FechaAlta { get; set; }
        public virtual string DescripcionLarga { get; set; }
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
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
