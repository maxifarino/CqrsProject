using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Beneficiario
{
    public class BeneficiarioDto
    {
        public Int64 BeneficiarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string Sexo { get; set; }
        public Int64 NumeroId { get; set; }
        public string CodigoPais { get; set; }
        public string NroDocumento { get; set; }
        public Decimal IdDomicilio { get; set; }
        public string CasoEspecial  { get; set; }
        public string Turno { get; set; }
        public bool Especial { get; set; }
        public Int64 IdSalita { get; set; }
    }
}
