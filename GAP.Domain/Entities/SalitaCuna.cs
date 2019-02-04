using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class SalitaCuna : ElementBase
    {
        public int SalaCunaId { get; set; }
        public int TurnoSalitaId { get; set; }
        public int TipoSalitaId { get; set; }
        public string CupoSalita { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string NombreSalita { get; set; }
        public int IdGrupoEtario{get;set;}
        public string CantidadBeneficiarios { get; set; }
        public string ComentarioBaja { get; set; }
        
        public override void Accept(IVisitor.VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
