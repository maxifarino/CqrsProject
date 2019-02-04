using GAP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class Integrante:ElementBase
    {
        public virtual int IntegranteGrupoFamiliarId { get; set; }
        [NoCAPS]
        public virtual string GrupoFamiliarId { get; set; }
        [NoCAPS]
        public virtual string CodPais { get; set; }
        public virtual string HorarioOcupacion { get; set; }
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
        public virtual Comunicacion Comunicacion { get; set; }
        public IntegrantePersona Caracteristica { get; set; }
        public IntegrantePersona PersonaSeleccionada { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public virtual Vinculo Vinculo { get; set; }
        public virtual string EsTutor { get; set; }
        public virtual DateTime FechaBaja { get; set; }
        public virtual string MotivoBaja { get; set; }
        public string EstadoSave { get; set; }

        public override void Accept(IVisitor.VisitorBase visitor)
        {
            throw new NotImplementedException();
        }

        public virtual string IdsProgramaSocial { get; set; }
        public virtual string IdsAporteHogar { get; set; }
        public virtual string AsisteGrado { get; set; }
        public virtual bool RecibeAtencion { get; set; }
        public virtual bool NecesitaAtencion { get; set; }
        public virtual bool CertificadoDiscapacidad { get; set; }
        public virtual string OtroAporte { get; set; }
        public virtual bool OtroAporteSeleccionado { get; set; }
        public virtual bool TrabajoFormal { get; set; }
        public virtual string EstadoCivilId { get; set; }
        public virtual string IdsBeneficioSocial { get; set; }
        public virtual bool EsDomicilioBeneficiario { get; set; }
        public virtual int  IdDomicilioBeneficiario { get; set; }
        public virtual bool PoseeProgramaSocial { get; set; }
        public virtual string CualProgramaSocial { get; set; }
    }
}
