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
    public class SocioAmbiental : ElementBase
    {
        //ID BENEFICIARIO--CONFIRMAR

        public int TipoSocioAmbiental { get; set; }
        public int IdSocioAmbiental { get; set; }
        public int BeneficiarioId { get; set; }
        //ID SALA CUNA---CONFIRMAR
        public int SalaCunaId { get; set; }
        //SOCIO AMBIENTAL
        public Int64? NumSocioId { get; set; }
        public DateTime? FechaEntrevista { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string Profesional { get; set; }
        public int CantidadNinos { get; set; }
        public string EspecificacionCredito { get; set; }
        public string LecheEspecial { get; set; }
        //RedSosten
        public List<GridSocioAmbiental> listRedSostenFamiliar{ get; set; }
        public string OtraRedSostenFamiliar { get; set; }
        //Aporte Hogar
        //public List<GridSocioAmbiental> listAporteHogar { get; set; }
        //public string OtroAporteHogar { get; set; }
        //Tarjeta Credito
        public Caracteristica Tarjeta{ get; set; }
        public bool TieneDeuda { get; set; }
        public string TipoDeuda { get; set; }
        //Vivienda
        public Caracteristica TipoVivienda{ get; set; }
        public Caracteristica AccesoVivienda { get; set; }
        public Caracteristica TenenciaTerreno { get; set; }
        public Caracteristica Muros { get; set; }
        public Caracteristica Techo { get; set; }
        public Caracteristica Piso { get; set; }
        public Caracteristica Banio { get; set; }
        public string UtilizacionBanio { get; set; }
        //Ambiente
        public List<GridSocioAmbiental> listAmbiente { get; set; }
        public int CantidadHabitaciones { get; set; }
        public Caracteristica Agua { get; set; }
        public Caracteristica Energia { get; set; }
        public string Cocina { get; set; }
        public Caracteristica Coccion { get; set; }
        //Crisis
        public List<GridSocioAmbiental> listSituacionCrisis { get; set; }
        public string ObserCrisis { get; set; }
        public string CursosRealizados { get; set; }
        public string GustosAprendizaje { get; set; }
        //Leche Consumo
        public int LecheId { get; set; }
        public int ObtencionLeche { get; set; }
        public bool EntregaLeche { get; set; }
        //Control Medico
        public List<GridSocioAmbiental> listPorgramaControlMedico { get; set; }
        public string OtroProgramaMedico { get; set; }
        public string InstitucionSalud { get; set; }
        public int TipoFamiliaId { get; set; }
        public string Observaciones { get; set; }
        
        public override void Accept(IVisitor.VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
