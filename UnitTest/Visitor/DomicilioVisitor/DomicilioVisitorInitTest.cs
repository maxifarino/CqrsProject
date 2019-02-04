using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.Visitor.VisitorsDomicilio;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using GAP.Domain.Entities;
using GAP.Base;

namespace UnitTest.Visitor.DomicilioVisitor
{
    [TestClass]
    public class DomicilioVisitorInitTest : UnitTestBase
    {
        private Mock<RepositoryLocalScheme> _mockedRepository;
        private Mock<VisitorDomiclioSave> _mockedVisitorDomicilioSave;
        private DomicilioServiceBusiness _domicilioServiceBusiness;

        public override void Initialize()
        {
            _mockedRepository = new Mock<RepositoryLocalScheme>();
            _mockedVisitorDomicilioSave = new Mock<VisitorDomiclioSave>() { CallBase = true };
        }

        [TestMethod]
        public void Save_domicilio_success()
        {
            var domicilio = new Domicilio() { Direccion = "cruz roja", Altura = 123 };
            _domicilioServiceBusiness = new DomicilioServiceBusiness(_mockedVisitorDomicilioSave.Object);
            _result = _domicilioServiceBusiness.ValidateSave(domicilio);

            Assert.AreEqual(true, _result.success);
        }

        [TestMethod]
        public void Save_domicilio_with_has_error_Altura()
        {
            var domicilio = new Domicilio() { Direccion = "cruz roja" };
            _domicilioServiceBusiness = new DomicilioServiceBusiness(_mockedVisitorDomicilioSave.Object);
            _result = _domicilioServiceBusiness.ValidateSave(domicilio);

            Assert.AreEqual(false, _result.success);
            //Assert.AreEqual(MessageError.DOMICILIO_SAVE_ALTURA, _result.GetErrors()[0].ToString());
        }

        [TestMethod]
        public void Save_domicilio_with_has_error_direccion()
        {
            var domicilio = new Domicilio() { Altura = 123 };
            _domicilioServiceBusiness = new DomicilioServiceBusiness(_mockedVisitorDomicilioSave.Object);
            _result = _domicilioServiceBusiness.ValidateSave(domicilio);

            Assert.AreEqual(false, _result.success);
           // Assert.AreEqual(MessageError.DOMICILIO_SAVE_ERROR_DIRECCION, _result.GetErrors()[0].ToString());
        }

    }
}
