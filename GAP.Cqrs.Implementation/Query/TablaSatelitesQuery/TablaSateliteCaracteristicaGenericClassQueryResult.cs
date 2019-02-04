using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.TablaSateliteCaracteristicaQueryResult
{
   public class TablaSateliteCaracteristicaGenericClassQueryResult : IQueryResult
    {
       public List<List<IdNombreDtoCaracteristica>> ListOfListDtoCaracteristica { get; set; }
       public TablaSateliteCaracteristicaGenericClassQueryResult()
       {
           ListOfListDtoCaracteristica = new List<List<IdNombreDtoCaracteristica>>();
       }
       
    }
}
