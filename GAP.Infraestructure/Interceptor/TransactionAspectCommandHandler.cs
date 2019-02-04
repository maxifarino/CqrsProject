using GAP.DataAcces;
using NHibernate.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure.Interceptor
{
    public class TransactionAspectCommandHandler : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            bool initTransaction = NHSessionManager.Instance.BeginTransaction();
            try
            {
                invocation.Proceed();

                if (invocation.ReturnValue is INHibernateProxy)
                    NHSessionManager.Instance.GetSession().GetSessionImplementation().PersistenceContext.Unproxy(invocation.ReturnValue);

                if (initTransaction)
                    NHSessionManager.Instance.CommitTransaction();
            }
            catch (ApplicationException)
            {
                if (initTransaction)
                    NHSessionManager.Instance.RollbackTransaction();

                throw;
            }
            catch (Exception e)
            {
                if (initTransaction)
                    NHSessionManager.Instance.RollbackTransaction();

                throw e;
            }
        }
    }
}
