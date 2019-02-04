using GAP.Base.Dto;
using GAP.Base.Dto.Personal;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalDomicilioQueryResult : IQueryResult
    {
        public DomicilioIdDto DomicilioId { get; set; }
        public List<PersonalRequisitosDto> requisitos { get; set; }
        public string esConflictiva { get; set; }
    }
}
