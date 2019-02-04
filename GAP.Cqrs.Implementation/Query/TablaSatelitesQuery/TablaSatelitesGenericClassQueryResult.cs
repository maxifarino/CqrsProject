using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.TablasSatelitesQueryResult
{
    public class TablaSatelitesGenericClassQueryResult : IQueryResult
    {
        public List<List<IdNombreDto>> ListOfListDto { get; set; }
        
        public TablaSatelitesGenericClassQueryResult()
        {
            ListOfListDto = new List<List<IdNombreDto>>();
            
        }

    }
}
