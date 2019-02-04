using GAP.Base;
using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    /*
     * Se utiliza en el Registrar Beneficiario
     */
    public class IntegranteSave : Persona
    {
        public virtual string IdVinculo { get; set; }
        public virtual string EsTutor { get; set; }
        public virtual string EstadoCivilId { get; set; }
        [NoCAPS]
        public virtual string ProvinciaOrigenId { get; set; }
        [NoCAPS]
        public virtual string DepartamentoOrigenId { get; set; }
        [NoCAPS]
        public virtual string LocalidadOrigenId { get; set; }
        [NoCAPS]
        public virtual string NacionalidadId { get; set; }
        public virtual string IdOcupacion { get; set; }
        public virtual string HorarioOcupacion { get; set; }
        public virtual string IdNivelEscolaridad { get; set; }
        public virtual string IdCoberturaMedica { get; set; }
        public virtual bool IdTieneObraSocial { get; set; }
        public virtual string IdObraSocial { get; set; }
        public virtual string IdsProgramaSocial { get; set; }
        public virtual string IdsBeneficioSocial { get; set; }
        public virtual bool EsDomicilioBeneficiario { get; set; }
        public virtual int IdDomicilioBeneficiario { get; set; }
        public virtual bool Indocumentado { get; set; }
        public virtual bool Programa { get; set; }
        public virtual string NombrePrograma { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            throw new NotImplementedException();
        }
    }
}
