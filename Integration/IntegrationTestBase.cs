using GAP.CqrsCore.Commands;
using GAP.CqrsCore.Querys;
using GAP.Infraestructure;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration
{
    public class IntegrationTestBase
    {

        public CommandDispatcher _CommandDispatcher;
        public QueryDispatcher _QueryDispatcher;

        [TestInitialize]
        public void InitTest()
        {
            new GuyWire().Wire();

            _CommandDispatcher = ServiceLocator.Current.GetInstance<CommandDispatcher>();
            _QueryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
        }


    }
}
