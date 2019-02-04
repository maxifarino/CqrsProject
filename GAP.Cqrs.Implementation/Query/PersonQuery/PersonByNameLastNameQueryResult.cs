using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult
{
    public class PersonByNameLastNameQueryResult : IQueryResult
    {
        public List<IdNombreDto> PersonDto { get; set; }
    }
}
