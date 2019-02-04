using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class SalasCunaBandejaDto
    {
        # region Entidad
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        # endregion 

        #region SalaCuna
        public Int64? IdSalaCuna { get; set; }
        public string NombreSalaCuna { get; set; }
        public string Estado { get; set; }
        public string Responsable { get; set; }
        public string Email { get; set; }
        public string Domicilio { get; set; }
        public string Codigo { get; set; }
        #endregion
    }
}
