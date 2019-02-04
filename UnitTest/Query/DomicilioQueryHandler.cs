using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.Query.DomicilioQuery;
using GAP.Cqrs.Implementation.QueryResult.DomicilioQuery;
using GAP.Repository.LocalScheme;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Query
{
    [TestClass]
    public class DomicilioQueryHandler : UnitTestBase
    {
        private Mock<RepositoryLocalScheme> _mockedRepository;
        private DomicilioQueryResult _domicilioQueryResult;

        private DomicilioByFilterQuery _domicilioByFilterQuery;

        public override void Initialize()
        {

        }

        [TestMethod]
        public void Get_domicilio_by_Localdiad_success()
        {
            _domicilioByFilterQuery = new DomicilioByFilterQuery() { StateDomicilio = DomicilioStateEnum.Localidad };
            _domicilioQueryResult = _QueryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioQueryResult>(_domicilioByFilterQuery);

        }



    }
}
