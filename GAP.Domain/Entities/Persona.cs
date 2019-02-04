using GAP.Base;
using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public abstract class Persona:ElementBase
    {
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Cuit { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public virtual DateTime? FechaNacimiento { get; set; }
        public virtual string NumeroDocumento { get; set; }
        public virtual string EstadoCivilId { get; set; }
        [NoCAPS]
        public virtual string SexoId { get; set; }
        public virtual string TelefonoCelular { get; set; }
        public virtual string Mail { get; set; }
        public virtual string TelefonoAlternativo { get; set; }
        public virtual string CodAreaAlternativo { get; set; }
        public virtual string CodArea { get; set; }
        [NoCAPS]
        public virtual string CodigoPais { get; set; }
        public virtual string Nacionalidad { get; set; }
        public virtual int? LocalidadId { get; set; }
        [NoCAPS]
        public virtual string TipoDocumentoId { get; set; }
        [NoCAPS]
        public virtual string CodigoPaisTd { get; set; }
        [NoCAPS]
        public virtual string OrganismoEmisor { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        //[NoCAPS]
        //public virtual List<String> TipoDocumento { get; set; }
        public virtual int NumeroId { get; set; }
        [NoCAPS]
        public virtual Caracteristica TieneObraSocial { get; set; }
        [NoCAPS]
        public virtual Caracteristica GrupoSanguineo { get; set; }
        [NoCAPS]
        public virtual Caracteristica ObraSocial { get; set; }
        [NoCAPS]
        public virtual Caracteristica Ocupacion { get; set; }
        [NoCAPS]
        public virtual Caracteristica ProgramaSocial { get; set; }
        [NoCAPS]
        public virtual Caracteristica NivelEscolaridad { get; set; }
        [NoCAPS]
        public virtual Caracteristica Enfermedad { get; set; }
        [NoCAPS]
        public virtual Caracteristica Discapacidad { get; set; }
        [NoCAPS]
        public virtual Caracteristica CoberturaMedica { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
