using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.ProvisionProductos
{
    public class ProvisionProductosReporteCEDto
    {
        #region SALA CUNA
        public Int64 IdSalaCuna { get; set; }
        public string NombreSalaCuna { get; set; }
        public string CodigoSalaCuna { get; set; }
        #endregion

        #region PERSONA JURIDICA
        public string NombrePersonaJuridica { get; set; }
        public string NombreTipoPersonaJuridica { get; set; }
        public string Barrio { get; set; }
        public string Localidad { get; set; }
        public string Departamento { get; set; }
        public string Capital { get; set; }
        public string Ubicacion { get { return ((Capital == "S") ? "CAPITAL" : "INTERIOR"); } }
        public string Domicilio { get; set; }

        #endregion

        #region DATOS Casos Especiales
        public string EsCasoEspecial { get; set; }
        public bool CasoEspecial { get { return ((EsCasoEspecial == "S") ? true : false); } }
        public Decimal NroOrden { get; set; }
        public DateTime? FechaAltaDefinitiva { get; set; }
        public Decimal CantBenef0A6MesesCE { get; set; }
        public Decimal CantBenef7A12MesesCE { get; set; }
        public Decimal CantBenef1AnioCE { get; set; }
        public Decimal CantBenef2AniosCE { get; set; }
        public Decimal CantBenef3AniosCE { get; set; }
        public Decimal CantBenefMayor3AniosCE { get; set; }
        public Decimal CantTotalBenefCE { get; set; }
        public Decimal LecheMaternizada1 { get; set; }
        public Decimal LecheMaternizada2 { get; set; }
        public Decimal LecheMaternizada3 { get; set; }
        public Decimal LecheFortificada { get; set; }
        public Decimal LecheEspecial { get; set; }
        public Decimal LecheEnteraFluida { get; set; }
        public Decimal PanialesM { get; set; }
        public Decimal PanialesG { get; set; }
        public Decimal PanialesXG { get; set; }
        public Decimal PanialesXXG { get; set; }
        #endregion

    }
}
