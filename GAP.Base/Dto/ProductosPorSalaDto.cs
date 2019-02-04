using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class ProductosPorSalaDto
    {
        #region SALA CUNA
        public Int64 SalaCunaId { get; set; }
        public string Entidad { get; set; }
        public string SalaCuna { get; set; }
        public string CodigoSalaCuna { get; set; }
        public string Domicilio { get; set; }
        public string CodigoUnico { get; set; }
        #endregion

        #region PRODUCTOS
        public Int64 LatasLecheMaternizada1 { get; set; }
        public Int64 LatasLecheMaternizada2 { get; set; }
        public Int64 LatasLecheMaternizada3 { get; set; }
        public Int64 LatasLecheEnteraFortificada { get; set; }
        public Int64 LatasLecheEspecial { get; set; }
        public Int64 LatasLecheFluidaEntera { get; set; }
        public Int64 CantLecheTotal { get; set; }
        public Int64 PaqPanialesTamanioP { get; set; }
        public Int64 PaqPanialesTamanioM { get; set; }
        public Int64 PaqPanialesTamanioG { get; set; }
        public Int64 PaqPanialesTamanioXG { get; set; }
        public Int64 PaqPanialesTamanioXXG { get; set; }
        public Int64 CantPanialesTotal { get; set; }

        #endregion

    }
}
