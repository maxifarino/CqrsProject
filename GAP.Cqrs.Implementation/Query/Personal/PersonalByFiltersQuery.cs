using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query
{
    public class PersonalByFiltersQuery : QueryFilter
    {
        public int SalaId { get; set; }
        public int TurnoSalaId { get; set; }
        public bool DadoBaja { get; set; }

    }
}