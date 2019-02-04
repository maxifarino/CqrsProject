using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.ProvisionProductos
{
    public class ProvisionProductosReporteDto
    {

        //Parámetros de cálculo
        public float paramLecheA;
        public float paramLecheB;
        public float paramPanialA;
        public float paramPanial0a2Anios;
        public float paramPanial3Anios;

        public ProvisionProductosReporteDto()
        {
            
        }

        public void SetParametrosDeCalculo(float paramLecheA, float paramLecheB,
            float paramPanialA, float paramPanial0a2Anios, float paramPanial3Anios)
        {
            this.paramLecheA = paramLecheA;
            this.paramLecheB = paramLecheB;
            this.paramPanialA = paramPanialA;
            this.paramPanial0a2Anios = paramPanial0a2Anios;
            this.paramPanial3Anios = paramPanial3Anios;
        }

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

        #region DATOS
        public Decimal NroOrden { get; set; }
        public DateTime? FechaAltaDefinitiva { get; set; }
        public Decimal CantBeneficiarios0a6Meses { get; set; }
        public Decimal CantBeneficiarios6a12Meses { get; set; }
        public Decimal CantBeneficiarios1Anio { get; set; }
        public Decimal CantBeneficiarios2Anios { get; set; }
        public Decimal CantBeneficiarios3Anios { get; set; }
        public Decimal CantBeneficiariosMas3Anios { get; set; }
        #endregion

        #region DATOS Casos Especiales
        public string EsCasoEspecial { get; set; }
        public bool CasoEspecial { get { return ((EsCasoEspecial == "S") ? true : false); } }
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
        public Decimal LecheTotal { get { return LecheMaternizada1 + LecheMaternizada2 + LecheMaternizada3 + LecheFortificada + LecheEspecial + LecheEnteraFluida; } }
        public Decimal PanialesP { get; set; }
        public Decimal PanialesM { get; set; }
        public Decimal PanialesG { get; set; }
        public Decimal PanialesXG { get; set; }
        public Decimal PanialesXXG { get; set; }
        public Decimal PanialesTotal { get { return PanialesP + PanialesM + PanialesG + PanialesXG + PanialesXXG; } }
        #endregion

        #region DATOS CALCULADOS

        public int CantBeneficiariosPorSalaCuna
        {
            get
            {
                return (int)(CantBeneficiarios0a6Meses + CantBeneficiarios6a12Meses
                    + CantBeneficiarios1Anio + CantBeneficiarios2Anios + CantBeneficiarios3Anios);
            }
        }

        /// <summary>
        /// Calcula la cantidad de leche Maternizada 1 al valor entero redondeando hacia arriba.
        /// </summary>
        /// <param name="paramA"></param>
        /// <param name="paramB"></param>
        /// <returns></returns>
        public int CantLecheMaternizada1
        {
            get
            {
                if (!CasoEspecial)
                {
                    return (int)Math.Ceiling((double)(((float)CantBeneficiarios0a6Meses / paramLecheA) * paramLecheB));
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Calcula la cantidad de leche Maternizada 2 al valor entero redondeando hacia arriba.
        /// </summary>
        /// <param name="paramA"></param>
        /// <param name="paramB"></param>
        /// <returns></returns>
        public int CantLecheMaternizada2
        {
            get
            {
                if (!CasoEspecial)
                {
                    return (int)Math.Ceiling((double)(((float)CantBeneficiarios6a12Meses / paramLecheA) * paramLecheB));
                }
                else
                {
                    return 0;
                }
            }

        }

        /// <summary>
        /// Calcula la cantidad de leche Entera Fortificada al valor entero redondeando hacia arriba.
        /// </summary>
        /// <param name="paramA"></param>
        /// <param name="paramB"></param>
        /// <returns></returns>
        public int CantLecheEnteraFortificada
        {
            get
            {
                if (!CasoEspecial)
                {
                    return (int)Math.Ceiling((double)((((int)(CantBeneficiarios1Anio + CantBeneficiarios2Anios + CantBeneficiarios3Anios)) / paramLecheA) * paramLecheB));
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Calcula la cantidad total de leche.
        /// </summary>
        /// <param name="paramA"></param>
        /// <param name="paramB"></param>
        /// <returns></returns>
        public int CantLecheTotal
        {
            get
            {
                return CantLecheMaternizada1 + CantLecheMaternizada2 + CantLecheEnteraFortificada;
            }
        }

        public int CantPanialesP
        {
            get
            {
                return 0;
            }
        }
        public int CantPanialesM
        {
            get
            {
                return (int)Math.Floor((double)((float)(CantBeneficiarios0a6Meses + CantBeneficiarios6a12Meses) * paramPanial0a2Anios * paramPanialA / 10));
            }
        }
        public int CantPanialesG
        {
            get
            {
                return (int)Math.Floor((double)((float)CantBeneficiarios1Anio * (float)paramPanial0a2Anios * paramPanialA / 10));
            }
        }
        public int CantPanialesXG
        {
            get
            {
                return (int)Math.Floor((double)((float)CantBeneficiarios2Anios * (float)paramPanial0a2Anios * paramPanialA / 10));
            }
        }
        public int CantPanialesXXG
        {
            get
            {
                return (int)Math.Floor((double)((float)CantBeneficiarios3Anios * (float)paramPanial3Anios * paramPanialA / 8));
            }
        }
        public int CantPanialesTotal
        {
            get
            {
                return CantPanialesP + CantPanialesM + CantPanialesG + CantPanialesXG + CantPanialesXXG;
            }
        }
        #endregion
    }
}
