using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GAP.Base;
using GAP.DataAcces.Conventions;
using GAP.DataAcces.Mapping;
using GAP.Domain.Entities;
using NHibernate;
using NHibernate.Cache;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GAP.DataAcces
{
    public class NHSessionManager
    {
        public static bool GenerateDatabase;

        public static NHSessionManager Instance
        {
            get {

                NHSessionManager SessionManager = new NHSessionManager();
                return SessionManager; 
            }
        }

        private NHSessionManager()
        {
            InitSessionFactory();
        }

        private class Nested
        {
            internal static readonly NHSessionManager SessionManager = new NHSessionManager();
        }

        public void InitSessionFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[GlobalVars.ConnectionString].ConnectionString;

            FluentConfiguration fc = Fluently.Configure()
                
                .Database(OracleDataClientConfiguration.Oracle10.ConnectionString(c => c.Is(connectionString))
                .ShowSql()
                  //  .Driver<NHibernate.Driver.OracleDataClientDriver>()
                    .Driver<NHibernate.Driver.OracleManagedDataClientDriver>()
                  //  .ConnectionString(connectionString)
                    .ShowSql());

               //.Mappings(m => m.HbmMappings.AddFromAssemblyOf<BeneficiarioMap>());

               /*.Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<PersonMap>())

               .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<Person>()
                    .Conventions.Setup(c =>
                    {
                        c.Add<ColumnNameConvention>();
                        c.Add<ReferenceConvention>();
                        c.Add<PrimaryKeyNameConvention>();
                    }));*/

            _sessionFactory = fc.BuildSessionFactory();
        }



        public void RegisterInterceptor(IInterceptor interceptor)
        {
            if (ContextSession != null && ContextSession.IsOpen)
                throw new CacheException("No se puede registrar un interceptor cuando la sesion ya ha sido abierta");

            GetSession(interceptor);
        }

        #region NHibernate Session

        public ISession GetSession()
        {
            return GetSession(null);
        }

        private ISession GetSession(IInterceptor interceptor)
        {
            ISession session = ContextSession;

            if (session == null || !session.IsOpen)
            {
                session = interceptor != null ? _sessionFactory.OpenSession(interceptor) : _sessionFactory.OpenSession();
                ContextSession = session;
            }

            return session;
        }

        public void CloseSession()
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                session.Close();
                ContextSession = null;
            }

            ContextSession = null;
        }

        private ISession ContextSession
        {
            get
            {
                return IsInWebContext()
                    ? (ISession)HttpContext.Current.Items[SessionKey]
                    : (ISession)CallContext.GetData(SessionKey);
            }
            set
            {
                if (IsInWebContext())
                    HttpContext.Current.Items[SessionKey] = value;
                else
                    CallContext.SetData(SessionKey, value);
            }
        }

        #endregion

        #region NHibernate Transaction

        public bool HasOpenTransaction()
        {
            ITransaction transaction = ContextTransaction;
            return transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack;
        }

        public bool BeginTransaction()
        {
            ITransaction transaction = ContextTransaction;

            if (transaction == null)
            {
                transaction = GetSession().BeginTransaction();
                ContextTransaction = transaction;
                return true;
            }

            return false;
        }

        public void CommitTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                GetSession().Flush();
                if (HasOpenTransaction())
                {
                    transaction.Commit();
                    ContextTransaction = null;
                }
            }
            catch (HibernateException)
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                CloseSession();
            }
        }

        public void RollbackTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                    transaction.Rollback();

                ContextTransaction = null;
            }
            finally
            {
                CloseSession();
            }
        }

        private ITransaction ContextTransaction
        {
            get
            {
                return IsInWebContext()
                    ? (ITransaction)HttpContext.Current.Items[TransactionKey]
                    : (ITransaction)CallContext.GetData(TransactionKey);
            }
            set
            {
                if (IsInWebContext())
                    HttpContext.Current.Items[TransactionKey] = value;
                else
                    CallContext.SetData(TransactionKey, value);
            }
        }

        #endregion

        private static bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }

        private const string TransactionKey = "CONTEXT_TRANSACTION";
        private const string SessionKey = "CONTEXT_SESSION";
        private ISessionFactory _sessionFactory;
    }

}
