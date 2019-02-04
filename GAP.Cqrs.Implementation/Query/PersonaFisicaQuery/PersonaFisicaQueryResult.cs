using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.PersonaFisicaResult
{
    public class PersonaFisicaQueryResult : IQueryResult
    {
        public IList<PersonaFisicaDto> PersonasFisicas { get; set; }
    }
}
