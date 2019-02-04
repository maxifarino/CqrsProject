using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class EntidadDetalleDto
    {

        public string FormaJuridica { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Cuit { get; set; }
        public string Mail { get; set; }
        public string TelFijo { get; set; }
        public string IdentificacionSede { get; set; }
        public string NombreSede { get; set; }
        public string Domicilio { get; set; }
        public string Responsable { get; set; }
        public string CelularResponsable { get; set; }
        public string MailResponsable { get; set; }
        public string Cbu { get; set; }
        public string EntidadBancaria { get; set; }
        public string Sucursal { get; set; }
        public string NumeroCuenta { get; set; }
        public List<SalaCunaVerEntidadDto> SalasCunas { get; set; }
    }
}
