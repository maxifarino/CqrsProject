using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.PersonalPorSalaQuery
{
    public class PersonalPorSalaQuery : QueryFilter
    {
        public int? SalaCunaId { get; set; }
        public int? PersonaJuridicaId { get; set; }
        public string Codigo { get; set; }
        public int? Turno { get; set; }
        public string Conflicto { get; set; }
        public Boolean Baja { get; set; }

    }
}
