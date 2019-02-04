using GAP.CqrsCore.Querys;
using GAP.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GAP.Cqrs.Implementation.QueryResult.Rol
{
    public class RolByFiltersQueryResults : IQueryResult
    {
        public List<RolDto> RolDto { get; set; }
    }
}
