using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class PersonalPorSalaDto
    {
        // TODO: Tony Personal Agregar property.
        public string NombreEntidad { get; set; }
        public string NombreSala { get; set; }
        public string CodigoSalaCuna { get; set; }
        public string ApellidoPersonal { get; set; }
        public string NombrePersonal { get; set; }
        public string CargoPersonal { get; set; }
        public string TurnoSalita { get; set; }
        public string EsConflictiva { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; }

    }
}
