using System.Collections.Generic;

namespace GAP.CqrsCore.Querys
{
    
    public interface IQueryHandler<TParameter, TResult>
        where TParameter : IQuery
        where TResult : IQueryResult
    {   
        TResult Retrieve(TParameter query);
    }

}
