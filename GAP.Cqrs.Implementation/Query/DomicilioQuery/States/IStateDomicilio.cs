using GAP.Cqrs.Implementation.Query.DomicilioQuery;
using GAP.Cqrs.Implementation.QueryResult.DomicilioQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.Domicilio.States
{
    public interface IStateDomicilio
    {
         DomicilioQueryResult ExecuteState(DomicilioByFilterQuery query);
    }
}
