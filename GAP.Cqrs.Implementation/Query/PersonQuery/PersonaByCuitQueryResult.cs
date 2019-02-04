using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.PersonQuery
{
   public class PersonaByCuitQueryResult : IQueryResult
    {
       public List<PersonaFisicaDto> PersonasFisicas { get; set; }
    }
}
