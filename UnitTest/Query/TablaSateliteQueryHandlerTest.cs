using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.Query.TablaSatelitesQuery;
using GAP.Cqrs.Implementation.QueryResult.TablasSatelitesQueryResult;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Query
{
    [TestClass]
    public class TablaSateliteQueryHandlerTest : UnitTestBase
    {
        TablaSatelitesGenericClassQuery query;

        public override void Initialize()
        {

        }


        [TestMethod]
        public void Get_By_Filter_Sexo_success()
        {

            var listaEnum = new List<TablaSateliteEnum>() { };
            listaEnum.Add(TablaSateliteEnum.SEXO);
            listaEnum.Add(TablaSateliteEnum.TIPO_DOCUMENTO);
            
            query = new TablaSatelitesGenericClassQuery() { ListTablaSatelites = listaEnum };
            var result = _QueryDispatcher.Dispatch<TablaSatelitesGenericClassQuery, TablaSatelitesGenericClassQueryResult>(query);


        }

    }
}
