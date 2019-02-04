using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.ProvisionProductos
{
    public class ProvisionProductosSumarizadoDto
    {

        public int CantTotalBeneficiarios0a6Meses { get; set; }
        public int CantTotalBeneficiarios6a12Meses { get; set; }
        public int CantTotalBeneficiarios1Anio { get; set; }
        public int CantTotalBeneficiarios2Anios { get; set; }
        public int CantTotalBeneficiarios3Anios { get; set; }
        public int CantTotalBeneficiariosPorSalaCuna
        {
            get
            {
                return CantTotalBeneficiarios0a6Meses + CantTotalBeneficiarios6a12Meses + CantTotalBeneficiarios1Anio + CantTotalBeneficiarios2Anios + CantTotalBeneficiarios3Anios;
            }
        }

        public int CantTotalLecheMaternizada1 { get; set; }
        public int CantTotalLecheMaternizada2 { get; set; }
        public int CantTotalLecheEnteraFortificada { get; set; }
        public int CantTotalLeche
        {
            get
            {
                return CantTotalLecheMaternizada1 + CantTotalLecheMaternizada2 + CantTotalLecheEnteraFortificada;
            }
        }
        public int CantTotalPanialesP { get; set; }
        public int CantTotalPanialesM { get; set; }
        public int CantTotalPanialesG { get; set; }
        public int CantTotalPanialesXG { get; set; }
        public int CantTotalPanialesXXG { get; set; }
        public int CantTotalPaniales
        {
            get
            {
                return CantTotalPanialesP + CantTotalPanialesM + CantTotalPanialesG + CantTotalPanialesXG + CantTotalPanialesXXG;
            }
        }

        public void IncrementarCantTotalLecheMaternizada1(int inc)
        {
            CantTotalLecheMaternizada1 += inc;
        }
        public void IncrementarCantTotalLecheMaternizada2(int inc)
        {
            CantTotalLecheMaternizada2 += inc;
        }
        public void IncrementarCantTotalLecheEnteraFortificada(int inc)
        {
            CantTotalLecheEnteraFortificada += inc;
        }
        public void IncrementarCantTotalPanialesP(int inc) 
        {
            CantTotalPanialesP += inc;
        }
        public void IncrementarCantTotalPanialesM(int inc) 
        {
            CantTotalPanialesM += inc;
        }
        public void IncrementarCantTotalPanialesG(int inc)
        {
            CantTotalPanialesG += inc;
        }
        public void IncrementarCantTotalPanialesXG(int inc)
        {
            CantTotalPanialesXG += inc;
        }
        public void IncrementarCantTotalPanialesXXG(int inc)
        {
            CantTotalPanialesXXG += inc;
        }


                public int IncrementarCantTotalBeneficiarios0a6Meses(int inc) { return CantTotalBeneficiarios0a6Meses += inc; }
        public int IncrementarCantTotalBeneficiarios6a12Meses(int inc) { return CantTotalBeneficiarios6a12Meses += inc; }
        public int IncrementarCantTotalBeneficiarios1Anio(int inc) { return CantTotalBeneficiarios1Anio += inc; }
        public int IncrementarCantTotalBeneficiarios2Anios(int inc) { return CantTotalBeneficiarios2Anios += inc; }
        public int IncrementarCantTotalBeneficiarios3Anios(int inc) { return CantTotalBeneficiarios3Anios += inc; }
    }
}
