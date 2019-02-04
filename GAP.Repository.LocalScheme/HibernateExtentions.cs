using GAP.Base;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GAP.Repository.LocalScheme
{
    public static class HibernateExtentions
    {
          public static ISQLQuery CallFunction<T>(this ISession session , string sql){

              var spName = string.Format("{{ call {0}{1} }}", GlobalVars.NombreEsquema, sql);
              var query = session.CreateSQLQuery(spName);       

              query .SetResultTransformer(Transformers.AliasToBean<T>());
           return  query;
       }

       public static ISQLQuery CallFunction(this ISession session, string sql)
       {
           var spName = string.Format("{{ call {0}{1} }}", GlobalVars.NombreEsquema, sql);
           var query = session.CreateSQLQuery(spName);         
           return query;
       }

      
    }
}
