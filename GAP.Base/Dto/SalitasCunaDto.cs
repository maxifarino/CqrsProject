using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
   public class SalitasCunaDto
    {
        //Se corresponde al nivel de la sala cuna
        public Int64 SalitaID { get; set; }
        public string NombreTipoSalita { get; set; }
        public string NombreDeTurno { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public string CupoSalita { get; set; }
        public Decimal CantidadBeneficiarios { get; set; }
        public string CantidadPersonalActivo { get; set; }
        public int? UsuarioId { get; set; }
        public Int64 TipoSalitaId { get; set; }
        public Int64 TurnoSalitaId { get; set; }
        public Int64 GrupoEtarioId { get; set; }
        public string NombreGrupoEtario { get; set; }
        public string NombreSalita { get; set; }
        public string ComentarioBaja { get; set; }
    }
}
