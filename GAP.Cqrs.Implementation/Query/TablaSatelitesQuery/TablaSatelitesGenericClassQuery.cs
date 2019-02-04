using GAP.Base.Enumerations;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.TablaSatelitesQuery
{
    public class TablaSatelitesGenericClassQuery : IQuery
    {
        public List<TablaSateliteEnum> ListTablaSatelites { get; set; }
    }
}
