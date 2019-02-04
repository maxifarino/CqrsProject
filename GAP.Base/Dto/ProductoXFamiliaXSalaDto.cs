using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class ProductoXFamiliaXSalaDto
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string EsCasoEspecial { get; set; }
        public string AsisteASalaCuna { get; set; }
        public Decimal EdadBeneficiario { get; set; }
        public Decimal Hermanos0A6Meses { get; set; }
        public Decimal Hermanos7A12Meses { get; set; }
        public Decimal Hermanos1A3Anios { get; set; }
        public Decimal Hermanos4OMas { get; set; }
        public Decimal HermanosCE0a6Meses { get; set; }
        public Decimal HermanosCE7a12Meses { get; set; }
        public Decimal HermanosCE1A3Anios { get; set; }
        public Decimal HermanosCE4OMas { get; set; }
        public Decimal HermanosCETotal { get { return (HermanosCE0a6Meses + HermanosCE7a12Meses + HermanosCE1A3Anios + HermanosCE4OMas); } }
        public Decimal LECHE_M1 { get; set; }
        public Decimal LECHE_M2 { get; set; }
        public Decimal LECHE_FO { get; set; }
        public Decimal LECHE_M3 { get; set; }
        public Decimal LECHE_ENT_FLUIDA { get; set; }
        public Decimal LECHE_ESPECIAL { get; set; }
        public Decimal LecheTotal { get { return (LECHE_M1 + LECHE_M2 + LECHE_FO + LECHE_M3 + LECHE_ENT_FLUIDA + LECHE_ESPECIAL); } }
        public string NombreSalaCuna { get; set; }
        public string CodigoSalaCuna { get; set; }
        public string RazonSocial { get; set; }
        public string CodigoUnico { get; set; }
    }
}
