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
    public class BeneficiarioSave : Persona
    {

        [NoCAPS]
        public virtual string ProvinciaOrigenId { get; set; }
        [NoCAPS]
        public virtual string DepartamentoOrigenId { get; set; }
        [NoCAPS]
        public virtual string LocalidadOrigenId { get; set; }
        [NoCAPS]
        public virtual string NacionalidadId { get; set; }
        public virtual DateTime? FechaAlta { get; set; }
        public virtual int SalitaId { get; set; }
        public virtual bool AsistioGuarderia { get; set; }
        public virtual string NombreGuarderia { get; set; }
        public virtual bool EsAlergico { get; set; }
        public virtual string DetalleAlergico { get; set; }
        public virtual bool TomaMedicamentos { get; set; }
        public virtual string DetalleMedicamento { get; set; }
        public virtual bool CondicionParticular { get; set; }
        public virtual bool IdTieneObraSocial { get; set; }
        public virtual string IdObraSocial { get; set; }
        public virtual bool AsignacionUniversalHijo { get; set; }
        public virtual bool SituacionCritica { get; set; }
        public virtual string InstitucionMedica { get; set; }
        public virtual DateTime? FechaUltimoControl { get; set; }
        public virtual double? Peso { get; set; }
        public virtual int? Talla { get; set; }
        public virtual string IdGrupoSanguineo { get; set; }
        public virtual string IdEnfermedad { get; set; }
        public virtual string IdDiscapacidad { get; set; }
        public virtual string Observacion { get; set; }
        public virtual IntegranteSave Integrante { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public virtual Int64? IdLeche { get; set; }
        public virtual Int64? IdPanial { get; set; }
        public virtual Int64? IdMotivoEspecial { get; set; }
        public virtual bool Especial { get; set; }
        public virtual bool Programa { get; set; }
        public virtual string NombrePrograma { get; set; }

        public virtual string AsisteSala { get; set; }

        public bool MayorEdad()
        {
                if(!FechaNacimiento.HasValue)return false;
                var today = DateTime.Today;
                var age = today.Year - FechaNacimiento.Value.Year;
                if (FechaNacimiento > today.AddYears(-age)) age--;
                return age >= 18;
         }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
