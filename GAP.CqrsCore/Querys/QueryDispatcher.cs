

using Castle.Windsor;
using System.Collections.Generic;
namespace GAP.CqrsCore.Querys
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IWindsorContainer _container;

        public QueryDispatcher(IWindsorContainer container)
        {
            this._container = container;
        }

        public TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            this.UpperCase(query);
            var handler = this._container.Kernel.Resolve<IQueryHandler<TParameter, TResult>>();
            return handler.Retrieve(query);
        }

    }
}